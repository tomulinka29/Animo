using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Diar
{
    class EventManager
    {
        private List<Event> events;
        public string DataPath { get; private set; }


        public EventManager(List<Event> events)
        {
            this.events = events;
        }

        public void AddEvent(Event newEvent) => events.Add(newEvent);

        public void RemoveEvent(Event rEvent) => events.Remove(rEvent);

        public void RemoveEvent(DateTime from, DateTime to) {
            Event[] toRemove = events.Where(e => e.From >= from && e.To <= to).ToArray();

            if (toRemove.Length > 0)
            {
                events.RemoveRange(
                    events.IndexOf(toRemove[0]),toRemove.Length
                );
            }
        }

        public Event[] GetEventsFrom(DateTime from) { return events.Where(e => e.From >= from).ToArray(); }
        public Event[] GetEventsTo(DateTime to) { return events.Where(e => e.From <= to).ToArray(); }
        public Event[] GetEvents(DateTime from, DateTime to) { return events.Where(e => e.From >= from && e.To <= to).ToArray(); }
        public Event[] GetAllEvents() { return events.ToArray(); }
    }
}
