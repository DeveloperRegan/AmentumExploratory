using AmentumExploratory.Data;
using AmentumExploratory.Data.Entities;
using Microsoft.AspNetCore.Components;

namespace AmentumExploratory.Components.Pages
{
    public partial class ContactList
    {
        [Inject]
        public required DataAccessService DataAccess { get; set; }
        public List<Contact> Contacts { get; set; } = [];
        public string SearchText { get; set; } = string.Empty;
        public List<ContactReason> Filters { get; set; } = [ ContactReason.General, ContactReason.Inquiry, ContactReason.Pricing, ContactReason.Other ];
        public List<Contact> FilteredList { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            Contacts = await DataAccess.GetContacts();
            Filter();
        }

        public void ToggleFilter(ContactReason reason)
        {
            if (Filters.Contains(reason))
                Filters.Remove(reason);
            else
                Filters.Add(reason);

            this.Filter();
        }

        public void Filter()
        {
            this.FilteredList = Contacts.Where(x => x.Name!.Contains(SearchText)).ToList();
            this.FilteredList = Contacts.Where(x => x.Email!.Contains(SearchText)).ToList();
            this.FilteredList = Contacts.Where(x => Filters.Contains(x.Reason)).ToList();
        }
    }
}
