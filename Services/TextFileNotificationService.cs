namespace AmentumExploratory.Services;

public class TextFileNotificationService : INotificationService
{
    private readonly string _filePath = "notification.txt";
    public async Task SendNotification(string message, bool isSuccess = true)
    {
      await  File.AppendAllTextAsync(_filePath, message);
    }
}


