using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;

namespace Fluid
{
    public static class AutomationExtensions
    {
        public static void EnsureElementIsScrolledIntoView(this AutomationElement element)
        {
            if (!(bool) element.GetCurrentPropertyValue(AutomationElement.IsScrollItemPatternAvailableProperty))
                return;

            ScrollItemPattern scrollItemPattern = element.GetScrollItemPattern();
            scrollItemPattern.ScrollIntoView();
        }

        public static AutomationElement FindDescendentByConditionPath(this AutomationElement element,
                                                                      IEnumerable<Condition> conditionPath)
        {
            if (!conditionPath.Any())
                return element;

            AutomationElement result = conditionPath.Aggregate(element,
                                                               (parentElement, nextCondition) =>
                                                               parentElement == null
                                                                   ? null
                                                                   : parentElement.FindChildByCondition(nextCondition));

            return result;
        }

        public static AutomationElement FindDescendentByIdPath(this AutomationElement element,
                                                               IEnumerable<string> idPath)
        {
            IEnumerable<Condition> conditionPath =
                CreateConditionPathForPropertyValues(AutomationElement.AutomationIdProperty,
                                                     idPath.Cast<object>());

            return FindDescendentByConditionPath(element, conditionPath);
        }

        public static AutomationElement FindDescendentByNamePath(this AutomationElement element,
                                                                 IEnumerable<string> namePath)
        {
            IEnumerable<Condition> conditionPath = CreateConditionPathForPropertyValues(AutomationElement.NameProperty,
                                                                                        namePath.Cast<object>());

            return FindDescendentByConditionPath(element, conditionPath);
        }

        public static IEnumerable<Condition> CreateConditionPathForPropertyValues(AutomationProperty property,
                                                                                  IEnumerable<object> values)
        {
            IEnumerable<PropertyCondition> conditions = values.Select(value => new PropertyCondition(property, value));

            return conditions.Cast<Condition>();
        }

        /// <summary>
        /// Finds the first child of the element that has a descendant matching the condition path.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="conditionPath">The condition path.</param>
        /// <returns></returns>
        public static AutomationElement FindFirstChildHavingDescendantWhere(this AutomationElement element,
                                                                            IEnumerable<Condition> conditionPath)
        {
            return
                element.FindFirstChildHavingDescendantWhere(
                    child => child.FindDescendentByConditionPath(conditionPath) != null);
        }

        /// <summary>
        /// Finds the first child of the element that has a descendant matching the condition path.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        public static AutomationElement FindFirstChildHavingDescendantWhere(this AutomationElement element,
                                                                            Func<AutomationElement, bool> condition)
        {
            AutomationElementCollection children = element.FindAll(TreeScope.Children, Condition.TrueCondition);

            foreach (AutomationElement child in children)
                if (condition(child))
                    return child;

            return null;
        }

        /// <summary>
        /// Finds the children of the element that pass a test.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="condition">The condition.</param>
        /// <returns></returns>
        public static IEnumerable<AutomationElement> FindChildren(this AutomationElement element,
                                                                  Func<AutomationElement, bool> condition)
        {
            AutomationElementCollection children = element.FindAll(TreeScope.Children, Condition.TrueCondition);

            foreach (AutomationElement child in children)
                if (condition(child))
                    yield return child;
        }

        public static IEnumerable<AutomationElement> FindRawChildren(this AutomationElement parent)
        {
            AutomationElement element = TreeWalker.RawViewWalker.GetFirstChild(parent);
            while (element != null)
            {
                yield return element;
                element = TreeWalker.RawViewWalker.GetNextSibling(element);
            }
        }

        public static AutomationElement FindChildById(this AutomationElement element, string automationId)
        {
            AutomationElement result =
                element.FindChildByCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));

            return result;
        }

        public static AutomationElement FindChildByName(this AutomationElement element, string name)
        {
            AutomationElement result =
                element.FindChildByCondition(new PropertyCondition(AutomationElement.NameProperty, name));

            return result;
        }

        public static AutomationElement FindChildByClass(this AutomationElement element, string className)
        {
            AutomationElement result =
                element.FindChildByCondition(new PropertyCondition(AutomationElement.ClassNameProperty, className));

            return result;
        }

        public static AutomationElement FindChildByProcessId(this AutomationElement element, int processId)
        {
            AutomationElement result =
                element.FindChildByCondition(new PropertyCondition(AutomationElement.ProcessIdProperty, processId));

            return result;
        }

        public static AutomationElement FindChildByControlType(this AutomationElement element, ControlType controlType)
        {
            AutomationElement result =
                element.FindChildByCondition(new PropertyCondition(AutomationElement.ControlTypeProperty, controlType));

            return result;
        }

        public static AutomationElement FindChildByCondition(this AutomationElement element, Condition condition)
        {
            AutomationElement result = element.FindFirst(TreeScope.Children, condition);

            return result;
        }

        /// <summary>
        /// Finds the child text block of an element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static AutomationElement FindChildTextBlock(this AutomationElement element)
        {
            AutomationElement child = TreeWalker.RawViewWalker.GetFirstChild(element);

            if (child != null && child.Current.ControlType == ControlType.Text)
                return child;

            return null;
        }
    }
}