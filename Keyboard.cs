using System.Windows.Input;

namespace Fluid
{
    public class Keyboard
    {
        public static void Press(Key key)
        {
            Microsoft.Test.Input.Keyboard.Press(key);
        }

        public static void Release(Key key)
        {
            Microsoft.Test.Input.Keyboard.Release(key);
        }

        public static void Type(string someText)
        {
            Microsoft.Test.Input.Keyboard.Type(someText);
        }

        public static void Type(Key key)
        {
            Microsoft.Test.Input.Keyboard.Type(key);
        }
    }
}