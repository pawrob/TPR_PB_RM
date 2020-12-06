using System;
using System.Runtime.Serialization;

namespace TP_DL.Objects
{
    public abstract class Event : ISerializable
    {
        public Guid Id { get; }
        public DateTimeOffset eventDate { get; }

        public Event(Guid id, DateTimeOffset date)
        {
            Id = id;
            eventDate = date;
        }

        public Event(SerializationInfo info, StreamingContext context)
        {
            Id = (Guid)info.GetValue("Id", typeof(Guid));
            eventDate = info.GetDateTime("eventDate");
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id, typeof(Guid));
            info.AddValue("eventDate", eventDate);
        }
    }
}
