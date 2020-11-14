using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using TP;
using TP.Objects;

namespace TP
{
    class main
    {
        static void Main()
        {
            string fileName = (@"..\..\..\..\data.json");
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                List<Client> items = JsonConvert.DeserializeObject<List<Client>>(json);
                string Something = string.Join(",", items);
                Console.Write(Something);
            }
        }
    }
}
