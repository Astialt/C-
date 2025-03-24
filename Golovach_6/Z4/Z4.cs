using System;

public class ChatApplication
{
    public event EventHandler<MessageEventArgs> MessageReceived;
    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"[ChatApplication] Получено новое сообщение: {message}");
        OnMessageReceived(new MessageEventArgs(message));
    }
    protected virtual void OnMessageReceived(MessageEventArgs e)
    {
        MessageReceived?.Invoke(this, e); 
    }
}

public class MessageEventArgs : EventArgs
{
    public string Message { get; }

    public MessageEventArgs(string message)
    {
        Message = message;
    }
}

public class DesktopNotification
{
    public void ShowNotification(object sender, MessageEventArgs e)
    {
        Console.WriteLine($"[DesktopNotification] Всплывающее уведомление: {e.Message}");
    }
}

public class SoundAlert
{
    public void PlaySound(object sender, MessageEventArgs e)
    {
        Console.WriteLine($"[SoundAlert] Звуковой сигнал для сообщения: {e.Message}");
    }
}

public class MessageNotifier
{
    private readonly ChatApplication _chatApp;
    public MessageNotifier(ChatApplication chatApp)
    {
        _chatApp = chatApp;
    }

    public void Subscribe(DesktopNotification desktopNotification, SoundAlert soundAlert)
    {
        _chatApp.MessageReceived += desktopNotification.ShowNotification;
        _chatApp.MessageReceived += soundAlert.PlaySound;
    }

    public void Unsubscribe(DesktopNotification desktopNotification, SoundAlert soundAlert)
    {
        _chatApp.MessageReceived -= desktopNotification.ShowNotification;
        _chatApp.MessageReceived -= soundAlert.PlaySound;
    }
}

class Program
{
    static void Main()
    {
        ChatApplication chatApp = new ChatApplication();

        DesktopNotification desktopNotification = new DesktopNotification();
        SoundAlert soundAlert = new SoundAlert();

        MessageNotifier notifier = new MessageNotifier(chatApp);

        notifier.Subscribe(desktopNotification, soundAlert);

        chatApp.ReceiveMessage("Привет, как дела?");
        chatApp.ReceiveMessage("У вас новое уведомление!");

        notifier.Unsubscribe(desktopNotification, soundAlert);

        chatApp.ReceiveMessage("Это сообщение никто не получит.");
    }
}
