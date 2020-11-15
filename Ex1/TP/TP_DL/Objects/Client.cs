using System;
using System.Collections.Generic;
using System.Text;

namespace TP_DL.Objects
{
    public class Client
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
    }

    
}
