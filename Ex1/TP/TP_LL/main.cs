using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;
using TP;
using TP.Objects;

namespace TP_LL
{
    public class Mainn
    {
        public static void Main()
        {
            /*            string fileName = (@"..\..\..\..\data.json");

                        *//*            Client c1 = new Client("Andrzej", "Duda", 127301025);
                                    var json = new JavaScriptSerializer().Serialize(c1);
                                    //Console.WriteLine(json);

                                    DataService ds = new DataService(new DataRepository());

                                    ds.AddClient("Andrzej", "Duda", 127301025);

                                    DataContext dc = new DataContext();
                                    dc.Clients.Add(c1);

                                    var json2 = new JavaScriptSerializer().Serialize(dc);
                                    Console.WriteLine(json2);*//*

                        using (StreamReader r = new StreamReader(fileName))
                        {
                            string json = r.ReadToEnd();
                            *//*                DataContext dc = new DataContext();

                                            dynamic ddc = JsonConvert.DeserializeObject(json);
                                            string Something = string.Join(",", ddc);
                                            Console.Write(Something);*//*
                            DataContext dc = new DataContext();
                            dc = JsonConvert.DeserializeObject<DataContext>(json);
                            //List<Client> clients = new List<Client>();

                            foreach (var item in dc.Clients)
                            {
                                Console.WriteLine("firstName: {0}, lastName: {1}, phoneNumber: {2}, id: {3}", item.FirstName, item.LastName, item.PhoneNumber, item.Id);
                            }
                            foreach (var item in dc.Cars)
                            {
                                //Console.WriteLine("firstName: {0}, lastName: {1}, phoneNumber: {2}, id: {3}", Client.FirstName, Client.LastName, Client.PhoneNumber, item.Id);
                            }
                            foreach (var item in dc.Factures)
                            {
                                //Console.WriteLine("firstName: {0}, lastName: {1}, phoneNumber: {2}, id: {3}", Client.FirstName, Client.LastName, Client.PhoneNumber, Client.Id);
                            }
                            foreach (var item in dc.WarehouseItems)
                            {
                                //Console.WriteLine("firstName: {0}, lastName: {1}, phoneNumber: {2}, id: {3}", Client.FirstName, Client.LastName, Client.PhoneNumber, Client.Id);
                            }
                        }*/

            //XML
/*            string fileName = (@"..\..\..\..\data.xml");

            DataContext dc = new DataContext();

            XmlSerializer serializer = new XmlSerializer(typeof(DataContext), new XmlRootAttribute("dataContext"));

            StringReader stringReader = new StringReader(fileName);

           
            dc = (DataContext)serializer.Deserialize(stringReader);*/




        }
    }
}
