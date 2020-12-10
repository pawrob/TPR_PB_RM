using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_Serializer;
using TP_DL.Objects;
using TP_DL;
using System;
using System.Linq;
using System.Runtime.Serialization;
using System.IO;
using TP_DL.RefenrecesModel;

namespace TP_UnitTests
{
    [TestClass]
    public class SerializationTest
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


        [TestMethod]
        public void TestOwnFormatter()
        {
            ClassA classA = new ClassA(1.2m, new DateTime(1997, 1, 1, 0, 0, 0), "TestA", null);
            ClassB classB = new ClassB(2.2m, new DateTime(1997, 2, 1, 0, 0, 0), "testB", null);
            ClassC classC = new ClassC(3.2m, new DateTime(1997, 3, 1, 0, 0, 0), "testC", null);


            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            classC.ClassAProperty = classA;

            CustomFormatter formatter = new CustomFormatter();

            using (Stream stream = File.Open("test.txt", FileMode.Create, FileAccess.ReadWrite))
            {
                formatter.Serialize(stream, classA);
            }

            ClassA classACopy;
            using (Stream stream = File.Open("test.txt", FileMode.Open, FileAccess.Read))
            {
                classACopy = (ClassA)formatter.Deserialize(stream);
            }

            Assert.AreSame(classACopy.ClassBProperty.ClassCProperty.ClassAProperty, classACopy);
        }

        [TestMethod]

        public void ClassASerializationATest()
        {
            ClassA classA = new ClassA(1.2m, new DateTime(1997, 1, 1, 0, 0, 0), "TestA", null);
            ClassB classB = new ClassB(2.2m, new DateTime(1997, 2, 1, 0, 0, 0), "testB", null);
            ClassC classC = new ClassC(3.2m, new DateTime(1997, 3, 1, 0, 0, 0), "testC", null);

            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            classC.ClassAProperty = classA;

            using (FileStream s = new FileStream("test.txt", FileMode.Create))
            {
                IFormatter f = new CustomFormatter();
                f.Serialize(s, classA);
            }

            string result = File.ReadAllText("test.txt");
            Assert.AreEqual(result, "TP_DL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|TP_DL.RefenrecesModel.ClassA|1|System.Decimal=DecimalProperty=1,20|System.DateTime=DateTimeProperty=1996-12-31 23:00:00|System.String=StringProperty=\"TestA\"|TP_DL.RefenrecesModel.ClassB=ClassBProperty=2\n"
                                  + "TP_DL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|TP_DL.RefenrecesModel.ClassB|2|System.Decimal=DecimalProperty=2,20|System.DateTime=DateTimeProperty=1997-01-31 23:00:00|System.String=StringProperty=\"testB\"|TP_DL.RefenrecesModel.ClassC=ClassCProperty=3\n"
                                  + "TP_DL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|TP_DL.RefenrecesModel.ClassC|3|System.Decimal=DecimalProperty=3,20|System.DateTime=DateTimeProperty=1997-02-28 23:00:00|System.String=StringProperty=\"testC\"|TP_DL.RefenrecesModel.ClassA=ClassAProperty=1\n");

           File.Delete("test.txt");
        }

        [TestMethod]
        public void ClassBSerializationTest()
        {
            ClassA classA = new ClassA(1.2m, new DateTime(1997, 1, 1, 0, 0, 0), "TestA", null);
            ClassB classB = new ClassB(2.2m, new DateTime(1997, 2, 1, 0, 0, 0), "testB", null);
            ClassC classC = new ClassC(3.2m, new DateTime(1997, 3, 1, 0, 0, 0), "testC", null);

            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            classC.ClassAProperty = classA;

            using (FileStream s = new FileStream("test.txt", FileMode.Create))
            {
                IFormatter f = new CustomFormatter();
                f.Serialize(s, classB);
            }

            string result = File.ReadAllText("test.txt");
            Assert.AreEqual(result, "TP_DL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|TP_DL.RefenrecesModel.ClassB|1|System.Decimal=DecimalProperty=2,20|System.DateTime=DateTimeProperty=1997-01-31 23:00:00|System.String=StringProperty=\"testB\"|TP_DL.RefenrecesModel.ClassC=ClassCProperty=2\n"
                                   +"TP_DL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|TP_DL.RefenrecesModel.ClassC|2|System.Decimal=DecimalProperty=3,20|System.DateTime=DateTimeProperty=1997-02-28 23:00:00|System.String=StringProperty=\"testC\"|TP_DL.RefenrecesModel.ClassA=ClassAProperty=3\n"
                                   +"TP_DL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|TP_DL.RefenrecesModel.ClassA|3|System.Decimal=DecimalProperty=1,20|System.DateTime=DateTimeProperty=1996-12-31 23:00:00|System.String=StringProperty=\"TestA\"|TP_DL.RefenrecesModel.ClassB=ClassBProperty=1\n");
            File.Delete("test.txt");
        }

        [TestMethod]
        public void ClassCSerializationTest()
        {
            ClassA classA = new ClassA(1.2m, new DateTime(1997, 1, 1, 0, 0, 0), "TestA", null);
            ClassB classB = new ClassB(2.2m, new DateTime(1997, 2, 1, 0, 0, 0), "testB", null);
            ClassC classC = new ClassC(3.2m, new DateTime(1997, 3, 1, 0, 0, 0), "testC", null);

            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            classC.ClassAProperty = classA;

            using (FileStream s = new FileStream("test.txt", FileMode.Create))
            {
                IFormatter f = new CustomFormatter();
                f.Serialize(s, classC);
            }

            string result = File.ReadAllText("test.txt");
            Assert.AreEqual(result, "TP_DL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|TP_DL.RefenrecesModel.ClassC|1|System.Decimal=DecimalProperty=3,20|System.DateTime=DateTimeProperty=1997-02-28 23:00:00|System.String=StringProperty=\"testC\"|TP_DL.RefenrecesModel.ClassA=ClassAProperty=2\n"
                                   +"TP_DL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|TP_DL.RefenrecesModel.ClassA|2|System.Decimal=DecimalProperty=1,20|System.DateTime=DateTimeProperty=1996-12-31 23:00:00|System.String=StringProperty=\"TestA\"|TP_DL.RefenrecesModel.ClassB=ClassBProperty=3\n"
                                   +"TP_DL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|TP_DL.RefenrecesModel.ClassB|3|System.Decimal=DecimalProperty=2,20|System.DateTime=DateTimeProperty=1997-01-31 23:00:00|System.String=StringProperty=\"testB\"|TP_DL.RefenrecesModel.ClassC=ClassCProperty=1\n");
            File.Delete("test.txt");
        }

        [TestMethod]
        public void ClassADeserializationATest()
        {
            ClassA classA = new ClassA(1.2m, new DateTime(1997, 1, 1, 0, 0, 0), "TestA", null);
            ClassB classB = new ClassB(2.2m, new DateTime(1997, 2, 1, 0, 0, 0), "testB", null);
            ClassC classC = new ClassC(3.2m, new DateTime(1997, 3, 1, 0, 0, 0), "testC", null);

            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            classC.ClassAProperty = classA;

            using (FileStream s = new FileStream(@"C:\Users\Pawrob\Desktop\test.txt", FileMode.Create))
            {
                IFormatter f = new CustomFormatter();
                f.Serialize(s, classA);
            }

            using (FileStream s = new FileStream(@"C:\Users\Pawrob\Desktop\test.txt", FileMode.Open))
            {
                IFormatter f = new CustomFormatter();
                ClassA testClass = (ClassA)f.Deserialize(s);
                Assert.IsTrue(testClass.ClassBProperty.ClassCProperty.ClassAProperty == testClass);
            }

            File.Delete("test.txt");
        }

        [TestMethod]
        public void ClassBDeserializationTest()
        {
            ClassA classA = new ClassA(1.2m, new DateTime(1997, 1, 1, 0, 0, 0), "TestA", null);
            ClassB classB = new ClassB(2.2m, new DateTime(1997, 2, 1, 0, 0, 0), "testB", null);
            ClassC classC = new ClassC(3.2m, new DateTime(1997, 3, 1, 0, 0, 0), "testC", null);

            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            classC.ClassAProperty = classA;

            using (FileStream s = new FileStream("test.txt", FileMode.Create))
            {
                IFormatter f = new CustomFormatter();
                f.Serialize(s, classB);
            }

            using (FileStream s = new FileStream("test.txt", FileMode.Open))
            {
                IFormatter f = new CustomFormatter();
                ClassB testClass = (ClassB)f.Deserialize(s);
                Assert.IsTrue(testClass.ClassCProperty.ClassAProperty.ClassBProperty == testClass);
            }

            File.Delete("test.txt");
        }

        [TestMethod]
        public void ClassCDeserializationTest()
        {
            ClassA classA = new ClassA(1.2m, new DateTime(1997, 1, 1, 0, 0, 0), "TestA", null);
            ClassB classB = new ClassB(2.2m, new DateTime(1997, 2, 1, 0, 0, 0), "testB", null);
            ClassC classC = new ClassC(3.2m, new DateTime(1997, 3, 1, 0, 0, 0), "testC", null);

            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            classC.ClassAProperty = classA;

            using (FileStream s = new FileStream("test.txt", FileMode.Create))
            {
                IFormatter f = new CustomFormatter();
                f.Serialize(s, classC);
            }

            using (FileStream s = new FileStream("test.txt", FileMode.Open))
            {
                IFormatter f = new CustomFormatter();
                ClassC testClass = (ClassC)f.Deserialize(s);
                Assert.IsTrue(testClass.ClassAProperty.ClassBProperty.ClassCProperty == testClass);
            }

            File.Delete("test.txt");
        }

       
    }
}
