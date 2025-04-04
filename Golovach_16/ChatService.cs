using Newtonsoft.Json;
using OrderManagement.Models;
using System;
using System.IO;
using System.IO.Pipes;
using System.Threading.Tasks;

namespace OrderManagement.Services
{
    public class ChatService
    {
        private const string PipeName = "ChatPipe";

        // Метод для отправки сообщения через Named Pipe
        public async Task SendMessageAsync(ChatMessage message)
        {
            try
            {
                using (var client = new NamedPipeClientStream(".", PipeName, PipeDirection.Out))
                {
                    await client.ConnectAsync(3000); // Ждем подключения до 3 секунд
                    using (var writer = new StreamWriter(client))
                    {
                        writer.AutoFlush = true;
                        string json = JsonConvert.SerializeObject(message);
                        await writer.WriteLineAsync(json);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка отправки сообщения: {ex.Message}");
            }
        }

        // Публичный метод для прослушивания входящих сообщений через Named Pipe
        public async Task ListenForMessagesAsync(Action<ChatMessage> onMessageReceived)
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    try
                    {
                        using (var server = new NamedPipeServerStream(PipeName, PipeDirection.In))
                        {
                            server.WaitForConnection();
                            using (var reader = new StreamReader(server))
                            {
                                string line = reader.ReadLine();
                                if (!string.IsNullOrEmpty(line))
                                {
                                    var message = JsonConvert.DeserializeObject<ChatMessage>(line);
                                    onMessageReceived?.Invoke(message);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка приема сообщения: {ex.Message}");
                    }
                }
            });
        }
    }
}
