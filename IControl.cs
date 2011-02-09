namespace Fluid
{
    #region Using Directives

    using System.Windows.Automation;

    #endregion

    public interface IControl
    {
        AutomationElement AutomationElement { get; set; }

        bool IsVisible { get; }
    }
}