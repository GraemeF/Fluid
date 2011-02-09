namespace Fluid
{
    public class TextBlock : Control<TextBlock>
    {
        public string Text
        {
            get { return AutomationElement.Current.Name; }
        }
    }
}