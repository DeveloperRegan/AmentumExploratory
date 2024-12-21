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

    public Contact ContactInformation { get; set; } = new();
    public List<ContactReason> ContactReasons { get; set; } = 
    [
        ContactReason.General,
        ContactReason.Inquiry,
        ContactReason.Pricing,
        ContactReason.Other
    ];

    public async Task SubmitForm()
    {
        var result =  await DataAccessService.AddContact(ContactInformation);
            
        var service = GetNotificationService("UI");
        if (result.IsSuccess is false) {
            await service.SendNotification(result.Error.Name, result.IsSuccess);
            return;
        }


        await service.SendNotification($"Successfully added {ContactInformation.ToString()}", result.IsSuccess);


        NavigationManager.NavigateTo("ContactList");
    }

    public INotificationService GetNotificationService(string serviceType)
    {
        return NotificationServiceFactory(serviceType);
    }
}
