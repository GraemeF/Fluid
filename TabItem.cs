namespace Fluid
{
    public class TabItem : Control<TabItem>, 
                           IContainer
    {
        public void Activate()
        {
            AutomationElement.GetSelectionItemPattern().Select();
        }
    }
}