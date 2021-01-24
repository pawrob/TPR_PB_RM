using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private DataService m_dataContext;
        private ObservableCollection<MyProduct> m_Products;
        private MyProduct m_CurrentProduct;
        private string m_CurrentMessage;


        public MainViewModel()
        {
            m_dataContext = new DataService();
            m_Products = m_dataContext.products;
            m_CurrentProduct = m_Products[0];
            m_CurrentMessage = "Welcome";
            AddSampleProduct = new Command(() => { CurrentMessage = m_dataContext.addProduct(new MyProduct(21, "Product", "JP-2137", "Purple", 100, 2.04m, "big", 21.15m)); Products = m_dataContext.products; });
            RemoveSampleProduct = new Command(() => { CurrentMessage = m_dataContext.removeProduct("Product"); Products = m_dataContext.products; });
            UpdateSampleProduct = new Command(() => { CurrentMessage = m_dataContext.updateProduct(CurrentProduct); Products = m_dataContext.products; });
        }
        public MainViewModel(DataService myDataContext)
        {
            m_dataContext = myDataContext;
            m_Products = m_dataContext.products;
            m_CurrentProduct = m_Products[0];
            m_CurrentMessage = "Welcome";

            AddSampleProduct = new Command(() => { CurrentMessage = m_dataContext.addProduct(new MyProduct(21, "Product", "JP-2137", "Purple", 100, 2.04m, "big", 21.15m)); Products = m_dataContext.products; });
            RemoveSampleProduct = new Command(() => { CurrentMessage = m_dataContext.removeProduct("Product"); Products = m_dataContext.products; });
            UpdateSampleProduct = new Command(() => { CurrentMessage = m_dataContext.updateProduct(CurrentProduct); Products = m_dataContext.products; });
        }


        public MyProduct EditedProduct
        {
            get => m_CurrentProduct;
        }

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
            get => m_CurrentMessage;
            set
            {
                m_CurrentMessage = value;
                onPropertyChanged(nameof(CurrentMessage));
            }
        }
        public Command AddSampleProduct
        {
            get; private set;
        }
        public Command RemoveSampleProduct
        {
            get; private set;
        }
        public Command UpdateSampleProduct
        {
            get; private set;
        }

        public DataService dataContext
        {
            get => m_dataContext;
            set
            {
                m_dataContext = value;
                Products = new ObservableCollection<MyProduct>(value.products);
            }
        }

        private void onPropertyChanged(string propertName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertName));
        }
    }
}
