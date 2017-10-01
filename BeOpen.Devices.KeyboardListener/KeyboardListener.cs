using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace BeOpen.Devices.KeyboardListener
{
    public class KeyboardListener : IDisposable
    {
        private readonly StringBuilder _buffer = new StringBuilder();
        private readonly GlobalKeyboardHook _hook;
        private bool _shiftPressed;

        public char EndSymbol { get; private set; }

        public char StartSymbol { get; private set; }

        public int StringLength { get; private set; }

        public ReadStrategy Strategy { get; private set; }

        /// <summary>
        ///     Creates new intanse of <see cref="KeyboardListener" />. New Text event will be fired on string with passed length.
        /// </summary>
        /// <param name="stringLength"></param>
        public KeyboardListener(int stringLength)
        {
            if (stringLength < 1)
            {
                throw new ArgumentOutOfRangeException($"{nameof(stringLength)} must be greater than 0");
            }
            StringLength = stringLength;
            Strategy = ReadStrategy.DependsOnLength;
            _hook = new GlobalKeyboardHook();
            _hook.KeyboardPressed += KeyPressed;
        }

        /// <summary>
        ///     Creates new intanse of <see cref="KeyboardListener" />. New Text event will be fired on EndSymbol.
        /// </summary>
        /// <param name="startSymbol"></param>
        /// <param name="endSymbol"></param>
        public KeyboardListener(char startSymbol, char endSymbol)
        {
            StartSymbol = startSymbol;
            EndSymbol = endSymbol;
            Strategy = ReadStrategy.DependsOnSymbols;
            _hook = new GlobalKeyboardHook();
            _hook.KeyboardPressed += KeyPressed;
        }

        /// <summary>
        ///     Creates new intanse of <see cref="KeyboardListener" />. New Text event will be fired on Enter.
        /// </summary>
        public KeyboardListener()
        {
            Strategy = ReadStrategy.DependsOnEnter;
            _hook = new GlobalKeyboardHook();
            _hook.KeyboardPressed += KeyPressed;
        }


        public void Dispose()
        {
            _hook.KeyboardPressed -= KeyPressed;
            _hook?.Dispose();
        }

        public event EventHandler<NewStringEventArgs> NewText;
        [DebuggerStepThrough]
        private void KeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            var pressedKey = (Keys) e.KeyboardData.VirtualCode;
            Debug.WriteLine($"Pressed key:{pressedKey}");
            if (pressedKey == Keys.LShiftKey)
            {
                _shiftPressed = e.KeyboardState == KeyboardState.KeyDown;
                return;
            }
            if (e.KeyboardState != KeyboardState.KeyDown)
            {
                return;
            }
            char resultSymbol;
            if (pressedKey.TryToChar(_shiftPressed, out resultSymbol))
            {
                AppendBuffer(resultSymbol, Strategy);
            }
            CheckBuffer(Strategy, pressedKey);
        }
        [DebuggerStepThrough]
        private void AppendBuffer(char result, ReadStrategy strategy)
        {
            if (strategy == ReadStrategy.DependsOnSymbols)
            {
                if (_buffer.Length==0 && result == StartSymbol)
                {
                    _buffer.Append(result);
                    return;
                }
                if (_buffer.Length > 0)
                {
                    _buffer.Append(result);
                }
            }
            else _buffer.Append(result);
        }
        [DebuggerStepThrough]
        private void CheckBuffer(ReadStrategy strategy, Keys key)
        {
            switch (strategy)
            {
                case ReadStrategy.DependsOnLength:
                {
                    if (_buffer.Length >= StringLength)
                    {
                        var text = _buffer.ToString();
                        _buffer.Clear();
                            NewText?.Invoke(this, new NewStringEventArgs(text));
                        
                    }
                    break;
                }
                case ReadStrategy.DependsOnSymbols:
                {
                    char end;
                    if (key.TryToChar(_shiftPressed, out end))
                    {
                        if (end == EndSymbol)
                        {
                            var text = _buffer.ToString();
                            _buffer.Clear();
                            NewText?.Invoke(this, new NewStringEventArgs(text));
                            }
                    }
                    break;
                }
                case ReadStrategy.DependsOnEnter:
                {
                    if (key == Keys.Return)
                    {
                        var text = _buffer.ToString();
                        _buffer.Clear();
                        NewText?.Invoke(this, new NewStringEventArgs(text));
                        }
                    break;
                }
            }
        }

        /// <summary>
        ///     Reset state of <see cref="KeyboardListener" />.
        /// </summary>
        public void Reset()
        {
            _buffer.Clear();
        }

        /// <summary>
        ///     New Text event will be fired on string with passed length.
        /// </summary>
        /// <param name="stringLength"></param>
        public KeyboardListener ChangeReadStrategy(int stringLength)
        {
            if (stringLength < 1)
            {
                throw new ArgumentOutOfRangeException($"{nameof(stringLength)} must be greater than 0");
            }
            StringLength = stringLength;
            Strategy = ReadStrategy.DependsOnLength;
            _buffer.Clear();
            return this;
        }

        /// <summary>
        ///     New Text event will be fired on EndSymbol.
        /// </summary>
        /// <param name="startSymbol"></param>
        /// <param name="endSymbol"></param>
        public KeyboardListener ChangeReadStrategy(char startSymbol, char endSymbol)
        {
            StartSymbol = startSymbol;
            EndSymbol = endSymbol;
            Strategy = ReadStrategy.DependsOnSymbols;
            _buffer.Clear();
            return this;
        }

        /// <summary>
        ///     New Text event will be fired on Enter.
        /// </summary>
        public KeyboardListener ChangeReadStrategy()
        {
            Strategy = ReadStrategy.DependsOnEnter;
            _buffer.Clear();
            return this;
        }
    }
}