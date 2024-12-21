using AmentumExploratory.Data;
using AmentumExploratory.Data.Entities;
using Microsoft.AspNetCore.Components;

namespace AmentumExploratory.Components.Pages
{
    public partial class ContactForm
    {
        [Inject]
        public required NavigationManager NavigationManager { get; set; }
        [Inject]
        public required DataAccessService DataAccessService { get; set; }

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
            await DataAccessService.AddContact(ContactInformation);
            NavigationManager.NavigateTo("ContactList");
        }
    }
}
