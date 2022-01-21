
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;

namespace Diar
{
    class Program
    {
        public static Dictionary<string, Action<EventManager>> menuOptions = new Dictionary<string, Action<EventManager>>() {
            { "Show events", new Action<EventManager>(ShowEvents) },
            { "Add event",  /* new Action<EventManager>(AddEvent) */ null},
            { "Manage events", /* new Action<EventManager>(OpenEditMenu) */ null},
            { "Exit", new Action<EventManager>(Exit) }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello dude!");
            Console.WriteLine("===========");

            //LOAD
            EventManager diary = new EventManager(DataManager.LoadEvents("data.json"));
            
            //Draw menu
            DrawMenu(diary);


            //Saves and exits
            Exit(diary);
        }

        public static void DrawMenu(EventManager diary)
        {
            Console.Clear();
            //Show options
            foreach (var option in menuOptions)
                Console.WriteLine(option.Key);

            //Set cursor to the top
            Console.CursorTop -= menuOptions.Count;

            int minCursorY = Console.CursorTop;
            int maxCursorY = minCursorY + menuOptions.Count - 1;

            bool exitLoop = false;
            while (!exitLoop)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case (ConsoleKey)KeySettings.Keys.MoveUp:
                        if (Console.CursorTop > minCursorY)
                            Console.CursorTop--;
                        break;

                    case (ConsoleKey)KeySettings.Keys.MoveDown:
                        if (Console.CursorTop < maxCursorY)
                            Console.CursorTop++;
                        break;

                        //Confirm out choice
                    case (ConsoleKey)KeySettings.Keys.Confirm:

                        int index = Console.CursorTop - minCursorY;
                        if (index < menuOptions.Count && menuOptions.ElementAt(index).Value != null)
                        {
                            try
                            {
                                exitLoop = true;
                                Console.CursorTop = maxCursorY + 1;
                                    menuOptions.ElementAt(index).Value.Invoke(diary);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }

                        break;
                }
            }
        }

        public static void AddEvent(EventManager diary)
        {
            Console.Clear();
            Console.WriteLine("Add event menu");
            Console.WriteLine("..............");
            bool exitLoop = false;
            Console.WriteLine("Name: ");

            bool nameSet = false;

            while (!exitLoop)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case (ConsoleKey)KeySettings.Keys.Back:
                        ShowEvents(diary);
                        break;

                    //case (ConsoleKey)KeySettings.Keys.Confirm:
                        //Console.WriteLine(Console.ReadLine());
                      //  break;

                    default:

                        break;
                }
            }
        }
     
        private static void OpenEditMenu(EventManager diary)
        {

        }

        public static void ShowEvents(EventManager diary)
        {
            Console.Clear();

            //Set cursor to the top
            Console.CursorTop = 2;

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int minCursorY = Console.CursorTop;
            int maxCursorY = minCursorY + DateTime.DaysInMonth(year, month);

            DrawCallendar(diary, year, month);
            Console.CursorTop = 2;

            bool exitLoop = false;
            bool eventSelectionMode = false;
            int selectedEventIndex = 0;

            while (!exitLoop)
            {
                var key = Console.ReadKey(true);
            
                switch (key.Key)
                {
                    case (ConsoleKey)KeySettings.Keys.AddEvent:
                        if (!eventSelectionMode)
                        {
                            AddEvent(diary);
                        }
                        break;

                    //selecting events
                    case (ConsoleKey)KeySettings.Keys.SelectPreviousEvent:
                        if (eventSelectionMode && selectedEventIndex > 0) // if we can, we move left
                        {
                            var todayEvents = diary.GetEvents(new DateTime(year, month, Console.CursorTop - minCursorY - 1));

                            //move left and substract selected event index
                            selectedEventIndex--;
                            Console.CursorLeft -= todayEvents[selectedEventIndex].Name.Length + 2;
                        }
                        break;

                    case (ConsoleKey)KeySettings.Keys.SelectNextEvent:
                        if (eventSelectionMode)
                        {
                            var todayEvents = diary.GetEvents(new DateTime(year, month, Console.CursorTop - minCursorY - 1));
                            if (selectedEventIndex < todayEvents.Count - 1)
                            {
                                selectedEventIndex++;
                                Console.CursorLeft += todayEvents[selectedEventIndex].Name.Length+2;
                            }
                        }
                        break;

                    case (ConsoleKey)KeySettings.Keys.MoveUp:
                        if (Console.CursorTop > minCursorY && eventSelectionMode == false)
                            Console.CursorTop--;
                        break;
            
                    case (ConsoleKey)KeySettings.Keys.MoveDown:
                        if (Console.CursorTop < maxCursorY && eventSelectionMode == false)
                            Console.CursorTop++;
                        break;
            
                    case (ConsoleKey)KeySettings.Keys.Confirm:
                        if (Console.CursorTop > minCursorY+1)
                    {                           
                            var todayEvents = diary.GetEvents(new DateTime(year, month, Console.CursorTop - minCursorY - 1));

                            if (eventSelectionMode == false && todayEvents.Count > 0)
                            {
                                Console.CursorLeft = (Console.CursorTop - minCursorY - 1).ToString().Length + 4;
                                eventSelectionMode = true;
                            }
                        }
                        break;
            
                    case (ConsoleKey)KeySettings.Keys.Back:
                        if (eventSelectionMode)
                        {
                            Console.CursorLeft = 0;
                            eventSelectionMode = false;
                        }
                        else
                        {
                            exitLoop = true;
                            DrawMenu(diary);
                        }
                        break;
                }
            }
        }

        public static void DrawCallendar(EventManager diary, int year, int month)
        {
            var firstDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var lastDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));

            var tempDay = firstDay;

            //Print current year and month
            Console.WriteLine("xx:" + DateTime.Now.Month + ":" + DateTime.Now.Year);
            Console.WriteLine("----------------------");

            while (tempDay < lastDay)
            {
                Console.Write(tempDay.Day + " -> ");

                var todayEvents = diary.GetEvents(new DateTime(tempDay.Year, tempDay.Month, tempDay.Day));
                foreach (var ev in todayEvents)
                    Console.Write(ev.Name + "; ");

                Console.WriteLine();

                tempDay = tempDay.AddDays(1);
            }
        }

        //Exits an app
        public static void Exit(EventManager diary)
        {
            DataManager.SaveEvents(diary.GetAllEvents(), "data.json");
            Environment.Exit(0);
        }
    }
}
