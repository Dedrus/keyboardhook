using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BeOpen.Devices.KeyboardListener
{
    internal static class KeysExtension
    {
        private static Dictionary<Tuple<Keys, bool>, char> CharsMap = new Dictionary<Tuple<Keys, bool>, char>();

        static KeysExtension()
        {
            #region Letters

            CharsMap.Add(new Tuple<Keys, bool>(Keys.A, false), 'a');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.A, true), 'A');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.B, false), 'b');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.B, true), 'B');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.C, false), 'c');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.C, true), 'C');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.D, false), 'd');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D, true), 'D');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.E, false), 'e');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.E, true), 'E');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.F, false), 'f');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.F, true), 'F');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.G, false), 'g');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.G, true), 'G');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.H, false), 'h');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.H, true), 'H');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.I, false), 'i');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.I, true), 'I');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.J, false), 'j');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.J, true), 'J');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.K, false), 'k');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.K, true), 'K');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.L, false), 'l');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.L, true), 'L');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.M, false), 'm');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.M, true), 'M');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.N, false), 'n');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.N, true), 'N');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.O, false), 'o');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.O, true), 'O');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.P, false), 'p');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.P, true), 'P');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.Q, false), 'q');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.Q, true), 'Q');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.R, false), 'r');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.R, true), 'R');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.S, false), 's');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.S, true), 'S');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.T, false), 't');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.T, true), 'T');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.U, false), 'u');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.U, true), 'U');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.V, false), 'v');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.V, true), 'V');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.W, false), 'w');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.W, true), 'W');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.X, false), 'x');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.X, true), 'X');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.Y, false), 'y');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.Y, true), 'Y');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.Z, false), 'z');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.Z, true), 'Z');

            #endregion

            #region Digits

            CharsMap.Add(new Tuple<Keys, bool>(Keys.D0, false), '0');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D1, false), '1');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D2, false), '2');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D3, false), '3');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D4, false), '4');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D5, false), '5');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D6, false), '6');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D7, false), '7');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D8, false), '8');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D9, false), '9');

            #endregion

            #region SpecialCharacters

            CharsMap.Add(new Tuple<Keys, bool>(Keys.D0, true), ')');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D1, true), '!');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D2, true), '@');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D3, true), '#');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D4, true), '$');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D5, true), '%');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D6, true), '^');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D7, true), '&');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D8, true), '*');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.D9, true), '(');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.Oemtilde, false), '`');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.Oemtilde, true), '~');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.OemMinus, false), '-');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.OemMinus, true), '_');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.Oemplus, false), '=');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.Oemplus, true), '+');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.OemOpenBrackets, false), '[');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.OemOpenBrackets, true), '{');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.Oem1, false), ';');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.Oem1, true), ':');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.Oem5, false), '\\');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.Oem5, true), '|');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.Oem6, false), ']');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.Oem6, true), '}');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.Oem7, false), '\'');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.Oem7, true), '\"');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.Oemcomma, false), ',');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.Oemcomma, true), '<');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.OemPeriod, false), '.');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.OemPeriod, true), '>');

            CharsMap.Add(new Tuple<Keys, bool>(Keys.OemQuestion, false), '/');
            CharsMap.Add(new Tuple<Keys, bool>(Keys.OemQuestion, true), '?');

            #endregion
        }

        public static bool TryToChar(this Keys key, bool shiftPressed, out char result)
        {
            result = '\0';
            if (CharsMap.TryGetValue(new Tuple<Keys, bool>(key, shiftPressed), out result))
            {
                return true;
            }
            return false;
        }

    }
}