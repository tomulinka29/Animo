using System;
using System.Collections.Generic;
using System.Text;

namespace Diar
{
    class Event
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public object Attachment { get; set; }

        public Event()
        {
            From = DateTime.Now;
            To = DateTime.Now + new TimeSpan(1,0,0);

            Name = "New event";
            Description = "";
            Attachment = null;
        }

        public override string ToString()
        {
            return Name + "\n" +
                   "Od: " + From + "\n" +
                   "Do: " + To + "\n" +
                   "Popis: " + Description + "\n";
        }
    }
}
