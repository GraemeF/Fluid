namespace Fluid
{
    public class EditBox : Control<EditBox>
    {
        public bool IsReadOnly
        {
            get { return AutomationElement.GetValuePattern().Current.IsReadOnly; }
        }

        public string Text
        {
            get { return AutomationElement.GetValue(); }
            set { AutomationElement.SetValue(value); }
        }
    }
}