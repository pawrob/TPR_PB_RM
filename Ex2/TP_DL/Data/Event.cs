using System;

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
    }
}
