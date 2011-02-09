namespace Fluid
{
    #region Using Directives

    using System.Windows.Automation;

    #endregion

    public interface IContainer
    {
        AutomationElement AutomationElement { get; }
    }
}