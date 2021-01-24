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

        private DataService m_dataService;
        private ObservableCollection<MyProduct> m_Products;
        private MyProduct m_CurrentProduct;
        private string m_Message;
        public Command AddProduct { get; private set; }
        public Command RemoveProduct { get; private set; }
        public Command UpdateProduct { get; private set; }

        public MainViewModel()
        {
            m_dataService = new DataService();
            m_Products = m_dataService.products;
            m_CurrentProduct = m_Products[0];
            m_Message = "Hello!";

            AddProduct = new Command(() => { Task.Run(_AddProduct); });
            RemoveProduct = new Command(() => { Task.Run(_RemoveProduct); });
            UpdateProduct = new Command(() => { Task.Run(_UpdateProduct); });
        }

        public MainViewModel(DataService dataService)
        {
            m_dataService = dataService;
            m_Products = m_dataService.products;
            m_CurrentProduct = m_Products[0];
            m_Message = "Hello!";

            AddProduct = new Command(() => { Task.Run(_AddProduct); });
            RemoveProduct = new Command(() => { Task.Run(_RemoveProduct); });
            UpdateProduct = new Command(() => { Task.Run(_UpdateProduct); });
        }

        #region getters, setters
        public ObservableCollection<MyProduct> Products
        {
            get => m_Products;
            set
            {
                m_Products = value;
                onPropertyChanged(nameof(Products));
            }
        }
        public MyProduct CurrentProduct
        {
            get => m_CurrentProduct;
            set
            {
                m_CurrentProduct = value;
                onPropertyChanged(nameof(CurrentProduct));
            }
        }
        public string CurrentMessage
        {
            get => m_Message;
            set
            {
                m_Message = value;
                onPropertyChanged(nameof(CurrentMessage));
            }
        }
        public DataService dataContext
        {
            get => m_dataService;
            set
            {
                m_dataService = value;
                Products = new ObservableCollection<MyProduct>(value.products);
            }
        }
        #endregion

        #region tasks
        private void _AddProduct()
        {
            CurrentMessage = m_dataService.addProduct(new MyProduct(21, "Product", "JP-2137", "Purple", 100, 2.04m, "big", 21.15m)); 
            Products = m_dataService.products;
        }

        
        public void _RemoveProduct()
        {
            CurrentMessage = m_dataService.removeProduct("Product"); 
            Products = m_dataService.products;
        }


        public void _UpdateProduct()
        {
            CurrentMessage = m_dataService.updateProduct(CurrentProduct); 
            Products = m_dataService.products;
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        private void onPropertyChanged(string propertName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertName));
        }
    }
}
