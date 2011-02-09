namespace Fluid
{
    #region Using Directives

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Automation;

    #endregion

    public class ControlFinder<TControl> : IEnumerable<TControl>
        where TControl : IControl, new()
    {
        private readonly List<Func<AutomationElement, bool>> _conditions = new List<Func<AutomationElement, bool>>();

        public AutomationElement Parent { get; set; }

        /// <summary>
        /// 	Specifies the AutomationId of the control.
        /// </summary>
        /// <param name="id">
        /// AutomationId
        /// </param>
        /// <returns>
        /// </returns>
        public ControlFinder<TControl> Called(string id)
        {
            return Matching(x => x.Current.AutomationId == id);
        }

        public ControlFinder<TControl> In(Container container)
        {
            Parent = container.AutomationElement;
            return this;
        }

        public ControlFinder<TControl> Matching(Func<AutomationElement, bool> condition)
        {
            _conditions.Add(condition);
            return this;
        }

        #region IEnumerable members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region IEnumerable<TControl> members

        public IEnumerator<TControl> GetEnumerator()
        {
            if (Parent == null)
                throw new UIElementNotFoundException("There is no parent element to look in.");

            return
                Parent.
                    FindChildren(MeetingConditions).
                    Select(element => new TControl
                                          {
                                              AutomationElement = element
                                          }).
                    GetEnumerator();
        }

        #endregion

        private bool MeetingConditions(AutomationElement automationElement)
        {
            return _conditions.All(condition => condition(automationElement));
        }
    }
}