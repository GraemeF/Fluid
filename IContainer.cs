using System.Windows.Automation;

namespace Fluid
{
    public interface IContainer
    {
        AutomationElement AutomationElement { get; }
    }
}