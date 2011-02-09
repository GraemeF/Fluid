namespace Fluid
{
    #region Using Directives

    using System.Collections.Generic;

    #endregion

    public class ListBox : Control<ListBox>, 
                           IContainer
    {
        public IEnumerable<ListBoxItem> Items
        {
            get { return ListBoxItem.In(this); }
        }
    }
}