using AmentumExploratory.Data;
using AmentumExploratory.Data.Entities;
using AmentumExploratory.Services;
using Microsoft.AspNetCore.Components;

namespace AmentumExploratory.Components.Pages;

public partial class ContactForm
{
    [Inject]
    public required NavigationManager NavigationManager { get; set; }
    [Inject]
    public required DataAccessService DataAccessService { get; set; }

    [Inject]
    public required Func<string, INotificationService> NotificationServiceFactory { get; set; }

    [Parameter]
    public string NotificationType { get; set; } = NotificationServiceType.UI;
    private INotificationService NotificationService { get; set; }

    public Contact ContactInformation { get; set; } = new();
    public List<ContactReason> ContactReasons { get; set; } = 
    [
        ContactReason.General,
        ContactReason.Inquiry,
        ContactReason.Pricing,
        ContactReason.Other
    ];

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();
        NotificationService = GetNotificationService(NotificationType);
    }
    public async Task SubmitForm()
    {
        var result =  await DataAccessService.AddContact(ContactInformation);
            
        if (result.IsSuccess is false) {
            await NotificationService.SendNotification(result.Error.Name, result.IsSuccess);
            return;
        }


        await NotificationService.SendNotification($"Successfully added {ContactInformation.ToString()}", result.IsSuccess);


        NavigationManager.NavigateTo("ContactList");
    }

    public INotificationService GetNotificationService(string serviceType)
    {
        return NotificationServiceFactory(serviceType);
    }
}
