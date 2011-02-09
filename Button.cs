namespace Fluid
{
    public class Button : Control<Button>
    {
        public bool IsEnabled
        {
            get { return AutomationElement.Current.IsEnabled; }
        }

        public string Text
        {
            get { return AutomationElement.Current.Name; }
        }

        public void Click()
        {
            AutomationElement.GetInvokePattern().Invoke();
        }
    }
}