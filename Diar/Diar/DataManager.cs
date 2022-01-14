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
        public static List<Event> LoadEvents(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    string text = File.ReadAllText(path);
                    return JsonConvert.DeserializeObject<List<Event>>(text);
                }

                return null;
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
                if (events == null)
                    return false;

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


      
    }
}
