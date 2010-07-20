namespace Fluid
{
    public class EditBox : Control<EditBox>
    {
        public string Text
        {
            get { return AutomationElement.GetValue(); }
            set { AutomationElement.SetValue(value); }
        }

        public bool IsReadOnly
        {
            get { return AutomationElement.GetValuePattern().Current.IsReadOnly; }
        }
    }
}