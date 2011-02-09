namespace Fluid
{
    #region Using Directives

    using System;
    using System.Runtime.Serialization;

    #endregion

    [Serializable]
    public class UIElementNotFoundException : Exception
    {
        // For guidelines regarding the creation of new exception types, see
        // http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        // http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        public UIElementNotFoundException()
        {
        }

        public UIElementNotFoundException(string message)
            : base(message)
        {
        }

        public UIElementNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected UIElementNotFoundException(
            SerializationInfo info, 
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}