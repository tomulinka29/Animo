
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
            { "Add event",   new Action<EventManager>(AddEvent) },
            { "Manage events", new Action<EventManager>(OpenEditMenu) },
            { "Exit", new Action<EventManager>(Exit) }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Hello dude!");
            Console.WriteLine("===========");

            //LOAD
            EventManager diary = new EventManager(DataManager.LoadEvents("data.json"));

            DrawMenu(diary);
            //DrawCallendar();


            DataManager.SaveEvents(diary.GetAllEvents(), "data.json");
            Console.ReadLine();
        }

        public static void DrawMenu(EventManager diary)
        {
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
                        if (index < menuOptions.Count)
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
        
        }
        public static void Exit(EventManager diary)
        { 
        
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

                bool exitLoop = false;
                while (!exitLoop)
                {
                    var key = Console.ReadKey();

                    switch (key.Key)
                    {
                        case (ConsoleKey)KeySettings.Keys.MoveUp:
                                Console.CursorTop--;
                            break;

                        case (ConsoleKey)KeySettings.Keys.MoveDown:
                                Console.CursorTop++;
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

                var todayEvents = diary.GetEvents(
                    new DateTime(tempDay.Year, tempDay.Month, tempDay.Day, 0, 0, 0),
                    new DateTime(tempDay.Year, tempDay.Month, tempDay.Day, 23, 59, 59)
                    );
                foreach (var ev in todayEvents)
                    Console.Write(ev.Name + "; ");

                Console.WriteLine();

                tempDay = tempDay.AddDays(1);
            }
        }

    }
}
