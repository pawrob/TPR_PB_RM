using System;
using TP_DL.Objects;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Runtime.Serialization;

namespace TP_DL
{
    public class DataContext
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


    }
}
