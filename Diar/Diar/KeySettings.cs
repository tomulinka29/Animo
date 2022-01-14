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
            Confirm = ConsoleKey.Enter
        }

        public enum Actions { 
            AddEvent,
            RemoveEvent,
            EditEvent,
            Exit
        }
    }
}
