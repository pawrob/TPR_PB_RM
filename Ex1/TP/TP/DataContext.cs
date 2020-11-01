using System;
using TP.Objects;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TP
{
    public class DataContext
    {
        public List<Client> Clients = new List<Client>();
        public Dictionary<Guid,Car> Cars = new Dictionary<Guid,Car>();
        public ObservableCollection<Facture> Factures = new ObservableCollection<Facture>();
        public List<Stock> Stocks = new List<Stock>();
    }
}
