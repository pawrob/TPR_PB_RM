using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ViewModel;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace WPF_Test
{
    [TestClass]
    public class MainViewModelTest
    {
        private TestDataContext testDataContext;
        private InitData initData;
        private MainViewModel mvm;

        public MainViewModelTest()
        {
            initData = new InitData();
            testDataContext = new TestDataContext(initData);
            mvm = new MainViewModel(new Model.DataService(testDataContext));
        }

        [TestMethod]
        public void InitializeViewModelDataTest()
        {
            Assert.IsNotNull(mvm.dataContext);
            Assert.IsNotNull(mvm.Products);
            Assert.IsNotNull(mvm.CurrentProduct);
            Assert.IsNotNull(mvm.AddProduct);
            Assert.IsNotNull(mvm.RemoveProduct);
            Assert.IsNotNull(mvm.UpdateProduct);
        }
        [TestMethod]
        public void AddProductTaskTest()
        {
            mvm.AddProduct.Execute(null);
            Thread.Sleep(100);
            Assert.AreEqual("Product sucessfuly added", mvm.CurrentMessage);
        }

        [TestMethod]
        public void UpdateProductTaskTest()
        {
            mvm.UpdateProduct.Execute(null);
            Thread.Sleep(100);
            Assert.AreEqual("Update sucessful", mvm.CurrentMessage);
        }

        [TestMethod]
        public void RemoveProductTaskTest()
        {
            mvm.RemoveProduct.Execute(null);
            Thread.Sleep(100);
            Assert.AreEqual("Product removed", mvm.CurrentMessage);
        }
    }
}
