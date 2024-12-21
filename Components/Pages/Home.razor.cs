using AmentumExploratory.Logic;
using Microsoft.AspNetCore.Components;

namespace AmentumExploratory.Components.Pages
{
    public partial class Home
    {
        [Inject]
        public required ContextService ContextService { get; set; }
        public List<(string, string, DateTime)> PageVisits { get; set; } = [];

        protected override void OnInitialized()
        {
            PageVisits = ContextService.PageVisits;
        }
    }
}
