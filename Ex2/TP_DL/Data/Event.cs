using System;
using System.Runtime.Serialization;

namespace TP_DL.Objects
{
    public abstract class Event
    {
        public Guid Id { get; }
        public DateTimeOffset eventDate { get; }

        public Event(Guid id, DateTimeOffset date)
        {
            Id = id;
            eventDate = date;
        }

        public override bool Equals(object obj)
        {
            return obj is Event @event &&
                   Id.Equals(@event.Id) &&
                   eventDate.Equals(@event.eventDate);
        }
    }
}
