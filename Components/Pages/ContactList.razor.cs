using AmentumExploratory.Data;
using AmentumExploratory.Data.Entities;
using Microsoft.AspNetCore.Components;

namespace AmentumExploratory.Components.Pages;

public partial class ContactList
{
    [Inject]
    public required DataAccessService DataAccess { get; set; }
    public List<Contact> Contacts { get; set; } = [];
    private string _searchText = string.Empty;
    public string SearchText
    {
        get => _searchText;
        set
        {
            if (_searchText != value)
            {
                _searchText = value;
                _filteredList = null; // Reset the cached list
                StateHasChanged();
            }
        }
    }
    public List<ContactReason> Filters { get; set; } = [ ContactReason.General, ContactReason.Inquiry, ContactReason.Pricing, ContactReason.Other ];
    private IReadOnlyList<Contact>? _filteredList;

    public IReadOnlyList<Contact> FilteredList
    {
        get
        {
            if (_filteredList is not null && _filteredList.Any())
            {
                return _filteredList;
            }
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                _filteredList = Contacts.Where(x=> Filters.Contains(x.Reason)).ToList().AsReadOnly();
                return _filteredList;
            }

            return _filteredList ??= Contacts
        .Where(x => Filters.Contains(x.Reason) &&
            (
            x.Email!.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
            x.Name!.Contains(SearchText, StringComparison.OrdinalIgnoreCase)))
        .ToList().AsReadOnly();
        }
    }

    protected override async Task OnInitializedAsync()
    {
        Contacts = await DataAccess.GetContacts();
        StateHasChanged();
    }

    public void ToggleFilter(ContactReason reason)
    {
        if (Filters.Contains(reason))
            Filters.Remove(reason);
        else
            Filters.Add(reason);


        StateHasChanged();
    }
}
