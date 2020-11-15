using System;
using TP.Objects;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TP
{
    public class DataContext
    {
        private List<Client> clients;
        private Dictionary<Guid, Car> cars;
        private ObservableCollection<Facture> factures;
        private List<WarehouseItem> warehouse;

        public DataContext()
        {
            clients = new List<Client>();
            cars = new Dictionary<Guid, Car>();
            factures = new ObservableCollection<Facture>();
            warehouse = new List<WarehouseItem>();
        }

        public List<Client> Clients { get => clients; }
        public Dictionary<Guid, Car> Cars { get => cars; }
        public ObservableCollection<Facture> Factures { get => factures; }
        public List<WarehouseItem> WarehouseItems { get => warehouse; }
    }
}
