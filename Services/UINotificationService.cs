using Microsoft.AspNetCore.Components;


namespace AmentumExploratory.Services;

internal class UINotificationService: INotificationService
{
    private readonly NavigationManager _navigationManager;

    public UINotificationService(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
    }

    public  Task SendNotification(string message, bool isSuccess = true)
    {
         _navigationManager.NavigateTo($"javascript:alert('{message}')");

        return Task.CompletedTask;
        // Send notification to UI
    }
}


