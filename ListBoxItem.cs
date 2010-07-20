namespace Fluid
{
    public class ListBoxItem : Control<ListBoxItem>, IContainer
    {
        public void Select()
        {
            AutomationElement.GetSelectionItemPattern().Select();
        }
    }
}