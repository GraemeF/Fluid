using System.Windows.Automation;

namespace Fluid
{
    public abstract class Control<TControl> : IControl
        where TControl : IControl, new()
    {
        #region IControl Members

        public AutomationElement AutomationElement { get; set; }

        #endregion

        public bool IsVisible
        {
            get { return !AutomationElement.Current.IsOffscreen; }
        }

        public static ControlFinder<TControl> In(IContainer container, params string[] path)
        {
            AutomationElement element = container.AutomationElement;
            foreach (string automationId in path)
                element =
                    element.FindChildByCondition(new PropertyCondition(AutomationElement.AutomationIdProperty,
                                                                       automationId));

            return new ControlFinder<TControl> {Parent = element};
        }
    }
}