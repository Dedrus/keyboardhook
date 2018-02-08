using System;

namespace KeyboardListener
{
    public class NewSymbolEventArgs : EventArgs
    {
        private readonly char _symbol;

        public NewSymbolEventArgs(char symbol)
        {
            _symbol = symbol;
        }

        public char Symbol => _symbol;
    }
}