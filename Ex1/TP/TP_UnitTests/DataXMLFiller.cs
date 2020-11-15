using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Linq;
using TP_DL;
using TP_DL.Objects;

namespace TP_UnitTests
{
    class DataXMLFiller : IDataFiller
    {
        public DataXMLFiller() { }

        public Dictionary<string, string> Parse(XmlNode child)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (XmlNode element in child.ChildNodes)
            {
                dictionary.Add(element.Name, element.InnerText);
            }
            return dictionary;
        }

        public void InsertData(DataContext dataContext)
        {
            XmlDocument xmlDocument = new XmlDocument();
            string path = (@"..\..\..\..\data.xml");
            xmlDocument.Load(path);
            foreach (XmlNode node in xmlDocument.DocumentElement)
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    Dictionary<string, string> elements = Parse(child);
                    switch (node.Name)
                    {
                        case "clients":
                            dataContext.Clients.Add(new Client(elements["firstName"], elements["lastName"], long.Parse(elements["phoneNumber"]), Guid.Parse(elements["id"])));
                            break;
                        case "cars":
                            dataContext.Cars.Add(Guid.Parse(elements["id"]), new Car(elements["make"], elements["model"], elements["variant"], int.Parse(elements["horsepower"]), elements["color"], (VehicleType)Enum.Parse(typeof(VehicleType), elements["vehicleType"]), (FuelType)Enum.Parse(typeof(FuelType), elements["fuelType"]), (Transmission)Enum.Parse(typeof(Transmission), elements["transmission"])));
                            break;
                        case "warehouse":
                            dataContext.WarehouseItems.Add(new WarehouseItem(dataContext.Cars[Guid.Parse(elements["car"])], decimal.Parse(elements["price"]), Guid.Parse(elements["id"])));
                            break;
                        case "factures":
                            dataContext.Factures.Add(new Facture(dataContext.Clients.Find(c => c.Id.Equals(Guid.Parse(elements["client"]))), dataContext.WarehouseItems.Find(c => c.Id.Equals(Guid.Parse(elements["warehouseItem"]))), Guid.Parse(elements["id"]), Convert.ToDateTime(elements["dateOfEmployment"])));
                            break;
                    }
                }
            }
        }
    }
}
