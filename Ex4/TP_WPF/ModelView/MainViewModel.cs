using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private DataService dataService;
        private ObservableCollection<MyProduct> myProducts;
        private MyProduct myProduct;
        private string outputMessage;
        public Command AddProduct { get; private set; }
        public Command RemoveProduct { get; private set; }
        public Command UpdateProduct { get; private set; }

        public MainViewModel()
        {
            dataService = new DataService();
            myProducts = dataService.products;
            myProduct = myProducts[0];

            AddProduct = new Command(() => { Task.Run(_AddProduct); });
            UpdateProduct = new Command(() => { Task.Run(_UpdateProduct); });
            RemoveProduct = new Command(() => { Task.Run(_RemoveProduct); });
        }

        public MainViewModel(DataService dataService)
        {
            this.dataService = dataService;
            myProducts = this.dataService.products;
            myProduct = myProducts[0];

            AddProduct = new Command(() => { Task.Run(_AddProduct); });
            UpdateProduct = new Command(() => { Task.Run(_UpdateProduct); });
            RemoveProduct = new Command(() => { Task.Run(_RemoveProduct); });
        }

        #region getters, setters
        public ObservableCollection<MyProduct> Products
        {
            get => myProducts;
            set
            {
                myProducts = value;
                onPropertyChanged(nameof(Products));
            }
        }
        public MyProduct CurrentProduct
        {
            get => myProduct;
            set
            {
                myProduct = value;
                onPropertyChanged(nameof(CurrentProduct));
            }
        }
        public string CurrentMessage
        {
            get => outputMessage;
            set
            {
                outputMessage = value;
                onPropertyChanged(nameof(CurrentMessage));
            }
        }
        public DataService dataContext
        {
            get => dataService;
            set
            {
                dataService = value;
                Products = new ObservableCollection<MyProduct>(value.products);
            }
        }
        #endregion

        #region tasks
        private void _AddProduct()
        {
            CurrentMessage = dataService.addProduct(new MyProduct(21, "Product", "JP-2137", "Purple", 100, 2.04m, "big", 21.15m)); 
            Products = dataService.products;
        }

        public void _UpdateProduct()
        {
            CurrentMessage = dataService.updateProduct(CurrentProduct);
            Products = dataService.products;
        }

        public void _RemoveProduct()
        {
            CurrentMessage = dataService.removeProduct("Product"); 
            Products = dataService.products;
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string propertName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertName));
        }
    }
}
