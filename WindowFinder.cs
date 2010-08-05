using System;
using System.Diagnostics;
using System.Windows.Automation;
using Gallio.Framework.Assertions;
using MbUnit.Framework;

namespace Fluid
{
    public class WindowFinder : ControlFinder<Window>
    {
        private static readonly TimeSpan StartUpTimeout = new TimeSpan(0, 0, 60);
        private Process _process;

        public Window Titled(string title)
        {
            AutomationElement shell = null;

            try
            {
                Retry.
                    WithTimeout(StartUpTimeout).
                    Until(() =>
                              {
                                  shell = GetWindowFromDesktop(title);
                                  return shell != null;
                              });
            }
            catch (AssertionFailureException assertionFailureException)
            {
                throw new UIElementNotFoundException(
                    string.Format("Could not find a window titled \"{0}\".", title), assertionFailureException);
            }

            return new Window { AutomationElement = shell };
        }

        private AutomationElement GetWindowFromDesktop(string title)
        {
            if (_process != null && _process.HasExited)
                throw new UIElementNotFoundException(
                    "The owning process exited before the window was found.");

            return Parent.FindFirst(TreeScope.Children,
                new AndCondition(new PropertyCondition(AutomationElement.NameProperty, title),
                                 new PropertyCondition(AutomationElement.ProcessIdProperty, _process.Id)));
        }

        public WindowFinder OwnedBy(Process process)
        {
            _process = process;
            return this;
        }
    }
}