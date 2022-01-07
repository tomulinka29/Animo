using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Newtonsoft.Json;

namespace Diar
{
    class DataManager
    {

        [DllImport("user32.dll", EntryPoint = "GetKeyboardState", SetLastError = true)]
        private static extern bool NativeGetKeyboardState([Out] byte[] keyStates);


        public static List<Event> LoadEvents(string path)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<Event>>(path);
            }
            catch(Exception e)
            {
                Console.WriteLine("------------------");
                Console.WriteLine("Chyba při načítání: " + e.Message);
                Console.WriteLine("------------------");
                return null;
            }
            
        }


        public static bool SaveEvents(List<Event> events, string path)
        {
            try
            {
                string text = JsonConvert.SerializeObject(events);
                File.WriteAllText(path, text);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("------------------");
                Console.WriteLine("Chyba při načítání: " + e.Message);
                Console.WriteLine("------------------");
                return false;
            }
        }


        private static bool GetKeyboardState(byte[] keyStates)
        {
            if (keyStates == null)
                throw new ArgumentNullException("keyState");
            if (keyStates.Length != 256)
                throw new ArgumentException("The buffer must be 256 bytes long.", "keyState");
            return NativeGetKeyboardState(keyStates);
        }

        private static byte[] GetKeyboardState()
        {
            byte[] keyStates = new byte[256];
            if (!GetKeyboardState(keyStates))
                throw new Win32Exception(Marshal.GetLastWin32Error());
            return keyStates;
        }

        private static bool AnyKeyPressed()
        {
            byte[] keyState = GetKeyboardState();
            // skip the mouse buttons
            return keyState.Skip(8).Any(state => (state & 0x80) != 0);
        }
    }
}
