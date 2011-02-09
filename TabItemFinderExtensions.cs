namespace Fluid
{
    public static class TabItemFinderExtensions
    {
        public static ControlFinder<TabItem> WithHeading(this ControlFinder<TabItem> finder, string heading)
        {
            return finder.Matching(x => x.FindChildTextBlock().Current.Name == heading);
        }
    }
}