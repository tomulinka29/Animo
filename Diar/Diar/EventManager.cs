using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Diar
{
    class EventManager
    {
        private List<Event> events;

        public EventManager(List<Event> events)
        {
            if (events != null)
                this.events = events;
            else
                this.events = new List<Event>();
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

        public List<Event> GetEventsFrom(DateTime from) { return events.Where(e => e.From >= from).ToList(); }
        public List<Event> GetEventsTo(DateTime to) { return events.Where(e => e.From <= to).ToList(); }
        public List<Event> GetEvents(DateTime from, DateTime to) { return events.Where(e => e.From >= from && e.To <= to).ToList(); }
        public List<Event> GetAllEvents() { return events; }
    }
}
