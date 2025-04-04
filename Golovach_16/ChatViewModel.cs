using OrderManagement.Commands;
using OrderManagement.Models;
using OrderManagement.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OrderManagement.ViewModels
{
    public class ChatViewModel : ViewModelBase
    {
        // Исправлено имя класса: ChatService, а не ChatSevice
        private readonly ChatService _chatService;
        public ObservableCollection<ChatMessage> Messages { get; set; }
        public string NewMessageText { get; set; }
        public ICommand SendMessageCommand { get; }

        public ChatViewModel()
        {
            _chatService = new ChatService();
            Messages = new ObservableCollection<ChatMessage>();
            SendMessageCommand = new RelayCommand(async _ => await SendMessageAsync());
            // Запускаем прослушивание входящих сообщений в отдельном потоке
            Task.Run(() => _chatService.ListenForMessagesAsync(OnMessageReceived));
        }

        private async Task SendMessageAsync()
        {
            if (!string.IsNullOrWhiteSpace(NewMessageText))
            {
                var message = new ChatMessage
                {
                    Sender = "Пользователь", // Замените на имя аутентифицированного пользователя
                    Message = NewMessageText,
                    Timestamp = System.DateTime.Now
                };

                try
                {
                    await _chatService.SendMessageAsync(message); // Отправка сообщения
                }
                catch
                {
                    // Ошибки уже обрабатываются в ChatService
                }

                Messages.Add(message); // Локальное добавление сообщения
                NewMessageText = string.Empty;
                OnPropertyChanged(nameof(NewMessageText));
            }
        }

        private void OnMessageReceived(ChatMessage message)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Messages.Add(message); // Добавляем полученное сообщение в UI
            });
        }
    }
}
