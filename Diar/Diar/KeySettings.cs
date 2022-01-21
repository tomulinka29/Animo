using System;
using System.Collections.Generic;
using System.Text;

namespace Diar
{
    public static class KeySettings
    {
        public enum Keys { 
            MoveUp = ConsoleKey.UpArrow,
            MoveDown = ConsoleKey.DownArrow,
            Confirm = ConsoleKey.Enter,
            Back = ConsoleKey.Escape,
            SelectNextEvent = ConsoleKey.RightArrow,
            SelectPreviousEvent = ConsoleKey.LeftArrow,
            AddEvent = ConsoleKey.A
        }
    }
}
