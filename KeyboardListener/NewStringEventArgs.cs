using System;

namespace KeyboardListener
{
    public class NewStringEventArgs : EventArgs
    {
        private readonly string _text;

        public NewStringEventArgs(string text)
        {
            this._text = text;
        }

        public string Text
        {
            get { return this._text; }
        }
    }
}