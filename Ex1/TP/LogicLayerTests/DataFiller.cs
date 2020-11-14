using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using TP;
using TP.Objects;


namespace UnitTests
{
    public class DataFiller
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Client));
        Client C1;

        using(var reader = File.OpenText(@"..\data.xml"))
        {
           c = (Client) serializer.Deserialize(reader);
        }
    }
}
