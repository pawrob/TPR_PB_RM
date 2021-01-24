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
        [TestMethod]
        public void ConstructorTest()
        {
            MainViewModel mvm = new MainViewModel(new Model.DataService(new TestDataContext(new InitData())));
            Assert.IsNotNull(mvm.dataContext);
            Assert.IsNotNull(mvm.Products);
            Assert.IsNotNull(mvm.CurrentProduct);
            Assert.IsFalse(String.IsNullOrEmpty(mvm.CurrentMessage));
            Assert.IsNotNull(mvm.AddProduct);
            Assert.IsNotNull(mvm.RemoveProduct);
            Assert.IsNotNull(mvm.UpdateProduct);
        }
        [TestMethod]
        public void CommandsTest()
        {
            MainViewModel mvm = new MainViewModel(new Model.DataService(new TestDataContext(new InitData())));
            mvm.AddProduct.Execute(null);
            Thread.Sleep(100);
            Assert.AreEqual("Product sucessfuly added", mvm.CurrentMessage);
            mvm.RemoveProduct.Execute(null);
            Thread.Sleep(100);
            Assert.AreEqual("Product removed", mvm.CurrentMessage);
            mvm.UpdateProduct.Execute(null);
            Thread.Sleep(100);
            Assert.AreEqual("Product updated", mvm.CurrentMessage);
        }
    }
}
