using System.ComponentModel;

namespace KeyboardListener
{
    internal class GlobalKeyboardHookEventArgs : HandledEventArgs
    {
        public GlobalKeyboardHookEventArgs(
            LowLevelKeyboardInputEvent keyboardData,
            KeyboardState keyboardState)
        {
            KeyboardData = keyboardData;
            KeyboardState = keyboardState;
        }

        public KeyboardState KeyboardState { get; private set; }
        public LowLevelKeyboardInputEvent KeyboardData { get; private set; }
    }
}