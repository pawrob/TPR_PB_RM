using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TP;
using TP.Objects;

namespace TP_UnitTests
{
    class DataInsert : IDataFiller
    {
        public void InsertData(DataContext dataContext)
        {
            string fileName = (@"..\..\..\..\data.json");

            /*            Client c1 = new Client("Andrzej", "Duda", 127301025);
                        var json = new JavaScriptSerializer().Serialize(c1);
                        //Console.WriteLine(json);

                        DataService ds = new DataService(new DataRepository());

                        ds.AddClient("Andrzej", "Duda", 127301025);

                        DataContext dc = new DataContext();
                        dc.Clients.Add(c1);

                        var json2 = new JavaScriptSerializer().Serialize(dc);
                        Console.WriteLine(json2);*/

            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                /*                DataContext dc = new DataContext();

                                dynamic ddc = JsonConvert.DeserializeObject(json);
                                string Something = string.Join(",", ddc);
                                Console.Write(Something);*/
                dataContext = JsonConvert.DeserializeObject<DataContext>(json);
                List<Client> clients = new List<Client>();
                List<Car> cars = new List<Car>();
                List<Facture> factures = new List<Facture>();
                List<WarehouseItem> warehouseItems = new List<WarehouseItem>();

                foreach (var Client in dataContext.Clients)
                {
                    Console.WriteLine("firstName: {0}, lastName: {1}, phoneNumber: {2}, id: {3}", Client.FirstName, Client.LastName, Client.PhoneNumber, Client.Id);
                }

            }


        }
    }
}
