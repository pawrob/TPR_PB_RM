using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_Serializer;
using TP_DL.Objects;
using TP_DL;
using System;
using System.Linq;


namespace TP_UnitTests
{
    [TestClass]
    public class JsonDataSerializerTest
    {
        private readonly String pathToFile = "jsonSerializedData.json";

        [TestMethod]
        public void JsonSerializationAndDeserlializationTest()
        {
            DataContext dataContext = new DataContext();
            IDataFiller dataFiller = new DataManualFiller();

            dataFiller.InsertData(dataContext);

            JsonDataSerializer.Serialize(dataContext, pathToFile);

            DataContext deserializedDataContext = JsonDataSerializer.Deserialize<DataContext>(pathToFile);

            CollectionAssert.AreEqual(dataContext.Clients, deserializedDataContext.Clients);
            CollectionAssert.AreEqual(dataContext.Cars, deserializedDataContext.Cars);
            CollectionAssert.AreEqual(dataContext.WarehouseItems, deserializedDataContext.WarehouseItems);
            CollectionAssert.AreEqual(dataContext.BoughtCars, deserializedDataContext.BoughtCars);
            CollectionAssert.AreEqual(dataContext.SoldCars, deserializedDataContext.SoldCars);
        }

        

    }
}
