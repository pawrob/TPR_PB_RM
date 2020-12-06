using System;
using TP_DL.Objects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Runtime.Serialization;

namespace TP_DL
{
    public class DataContext : ISerializable
    {
        public List<Client> Clients { get; private set; }
        public Dictionary<Guid, Car> Cars { get; private set; }
        public ObservableCollection<SellCar> SoldCars { get; private set; }
        public ObservableCollection<BuyCar> BoughtCars { get; private set; }
        public List<WarehouseItem> WarehouseItems { get; private set; }

        public DataContext()
        {
            Clients = new List<Client>();
            Cars = new Dictionary<Guid, Car>();
            SoldCars = new ObservableCollection<SellCar>();
            BoughtCars = new ObservableCollection<BuyCar>();
            WarehouseItems = new List<WarehouseItem>();  
        }

        public DataContext(SerializationInfo info, StreamingContext context)
        {
            Clients = (List<Client>)info.GetValue("Clients", typeof(List<Client>));
            Cars = (Dictionary<Guid, Car>)info.GetValue("Cars", typeof(Dictionary<Guid, Car>));  //Dictionary<Guid, Car>();
            SoldCars = (ObservableCollection<SellCar>)info.GetValue("SoldCars", typeof(ObservableCollection<SellCar>));// ObservableCollection<SellCar>();
            BoughtCars = (ObservableCollection<BuyCar>)info.GetValue("BoughtCars", typeof(ObservableCollection<BuyCar>)); //ObservableCollection<BuyCar>();
            WarehouseItems = (List<WarehouseItem>)info.GetValue("WarehouseItems", typeof(List<WarehouseItem>));// List<WarehouseItem>();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            
            foreach (Client client in Clients)
            {
                client.GetObjectData(info, context);
            }
            foreach (KeyValuePair<Guid, Car> car in Cars)
            {
                car.Value.GetObjectData(info, context);
            }
            foreach (SellCar sellCar in SoldCars)
            {
                sellCar.GetObjectData(info, context);
            }
            foreach (BuyCar buyCar in BoughtCars)
            {
                buyCar.GetObjectData(info, context);
            }
            foreach (WarehouseItem warehouseItem in WarehouseItems)
            {
                warehouseItem.GetObjectData(info, context);
            }
            /*          info.AddValue("Cars", Cars);
                        info.AddValue("Clients", Clients);
                        info.AddValue("SoldCars", SoldCars);
                        info.AddValue("BoughtCars", BoughtCars);
                        info.AddValue("WarehouseItems", WarehouseItems);*/

        }
    }
}
