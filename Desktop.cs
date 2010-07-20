using System.Windows.Automation;

namespace Fluid
{
    public class Desktop
    {
        public static WindowFinder Window
        {
            get { return new WindowFinder {Parent = AutomationElement.RootElement}; }
        }
    }
}