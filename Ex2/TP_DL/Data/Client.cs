using System;
using System.Runtime.Serialization;

namespace TP_DL.Objects
{
    public class Client : ISerializable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNumber { get; set; }
        public Guid Id { get; set; }

        public Client(string firstName, string lastName, long phoneNumber, Guid id)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Id = id;
        }

        public Client(SerializationInfo info, StreamingContext context)
        {
            FirstName = info.GetString("FirstName");
            LastName = info.GetString("LastName");
            PhoneNumber = info.GetInt64("PhoneNumber");
            Id = (Guid)info.GetValue("Id", typeof(Guid));
        }

        public override string ToString()
        {
            return "Client: " + FirstName + " " + LastName + " " + "\nPhone Number: " + PhoneNumber;
        }
        public override bool Equals(object obj)
        {
            return obj is Client client &&
                   FirstName == client.FirstName &&
                   LastName == client.LastName &&
                   PhoneNumber == client.PhoneNumber;
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", FirstName);
            info.AddValue("LastName", LastName);
            info.AddValue("PhoneNumber", PhoneNumber);
            info.AddValue("Id", Id, typeof(Guid));
        }
    }
}
