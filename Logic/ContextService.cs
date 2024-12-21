namespace AmentumExploratory.Logic;

public class ContextService
{
    private readonly string[] availableRoutes = ["/", "/ContactForm", "/ContactList", "/LostCSS"];
    public List<(string, string, DateTime)> PageVisits { get; set; } = [];

    public void Register(string route, string location, DateTime time)
    {
        if (isFrameworkRoute(route))
        {
            return;
        }
        

        if (!availableRoutes.Contains(route) )
            throw new InvalidDataException("Unexpected tracked route.");

        PageVisits.Add((route, location, time));
    }

    // When Blazor loads there is a bunch of files that get loaded in the run time.  I have chosen to not track these files, because we would not log that we visited pictures.

    private bool isFrameworkRoute(string route) => route.Contains('_');
}
