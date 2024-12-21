namespace AmentumExploratory.Components.Layout
{
    public partial class NavMenu
    {
        public string Collapse { get; set; } = "collapse";
        public void ToggleNav()
        {
            Collapse = Collapse == "collapse" ? "" : "collapse";
        }
    }
}
