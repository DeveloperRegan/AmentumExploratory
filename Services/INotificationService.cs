namespace AmentumExploratory.Services;

public interface INotificationService
{
    
    Task SendNotification(string message, bool isSuccess = true);
}


