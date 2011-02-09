namespace Fluid
{
    #region Using Directives

    using System.Windows.Automation;

    #endregion

    public class Desktop
    {
        public static WindowFinder Window
        {
            get
            {
                return new WindowFinder
                           {
                               Parent = AutomationElement.RootElement
                           };
            }
        }
    }
}