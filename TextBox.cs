namespace Fluid
{
    public class TextBox : Control<TextBox>
    {
        public string Content
        {
            get { return AutomationElement.GetValue(); }
            set { AutomationElement.SetValue(value); }
        }
    }
}