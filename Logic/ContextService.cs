namespace AmentumExploratory.Logic
{
    public class ContextService
    {
        private readonly string[] availableRoutes = ["/", "/ContactForm", "/ContactList", "/LostCSS"];
        public List<(string, string, DateTime)> PageVisits { get; set; } = [];

        public void Register(string route, string location, DateTime time)
        {
            if (!availableRoutes.Contains(route))
                throw new InvalidDataException("Unexpected tracked route.");

            PageVisits.Add((route, location, time));
        }
    }
}
