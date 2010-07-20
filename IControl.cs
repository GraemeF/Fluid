using System.Windows.Automation;

namespace Fluid
{
    public interface IControl
    {
        AutomationElement AutomationElement { get; set; }
        bool IsVisible { get; }
    }
}