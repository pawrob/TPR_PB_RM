using System;
using TP_DL.Objects;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TP_DL
{
    public class DataContext
    {
        private List<Client> clients;
        private Dictionary<Guid, Car> cars;
        private ObservableCollection<Facture> factures;
        private ObservableCollection<BillOfSale> billesOfSale;
        private List<WarehouseItem> warehouse;

        public DataContext()
        {
            clients = new List<Client>();
            cars = new Dictionary<Guid, Car>();
            factures = new ObservableCollection<Facture>();
            warehouse = new List<WarehouseItem>();
            billesOfSale = new ObservableCollection<BillOfSale>();
        }

        public List<Client> Clients { get => clients; }
        public Dictionary<Guid, Car> Cars { get => cars; }
        public ObservableCollection<Facture> Factures { get => factures; }
        public ObservableCollection<BillOfSale> BillesOfSale { get => billesOfSale; }
        public List<WarehouseItem> WarehouseItems { get => warehouse; }
    }
}
