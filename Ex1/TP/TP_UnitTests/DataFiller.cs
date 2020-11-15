using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using TP;
using TP.Objects;


namespace UnitTests
{
    [TestClass]
    public class DataFiller
    {
        //private string jsonString;
        private const string fileName = (@"..\..\..\..\data.json");

        [TestMethod]
        public void LoadJson()
        {
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
