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
        public void PreserveReferencesTestForClassA()
        {
            ClassA classA = new ClassA(new DateTime(1997, 1, 1, 0, 0, 0), 1.2m, "TestA", null);
            ClassB classB = new ClassB(new DateTime(1997, 2, 1, 0, 0, 0), 2.2m, "testB", null);
            ClassC classC = new ClassC(new DateTime(1997, 3, 1, 0, 0, 0), 3.2m, "testC", null);

            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            classC.ClassAProperty = classA;

            CustomFormatter formatter = new CustomFormatter();
            using (Stream stream = File.Open("test.txt", FileMode.Create, FileAccess.ReadWrite))
            {
                formatter.Serialize(stream, classA);
            }

            ClassA classADuplicate;
            using (Stream stream = File.Open("test.txt", FileMode.Open, FileAccess.Read))
            {
                classADuplicate = (ClassA)formatter.Deserialize(stream);
            }
            Assert.AreSame(classADuplicate.ClassBProperty.ClassCProperty.ClassAProperty, classADuplicate);
        }

        [TestMethod]
        public void PreserveReferencesTestForClassB()
        {
            ClassA classA = new ClassA(new DateTime(1997, 1, 1, 0, 0, 0), 1.2m, "TestA", null);
            ClassB classB = new ClassB(new DateTime(1997, 2, 1, 0, 0, 0), 2.2m, "testB", null);
            ClassC classC = new ClassC(new DateTime(1997, 3, 1, 0, 0, 0), 3.2m, "testC", null);

            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            classC.ClassAProperty = classA;

            CustomFormatter formatter = new CustomFormatter();
            using (Stream stream = File.Open("test.txt", FileMode.Create, FileAccess.ReadWrite))
            {
                formatter.Serialize(stream, classB);
            }

            ClassB classBDuplicate;
            using (Stream stream = File.Open("test.txt", FileMode.Open, FileAccess.Read))
            {
                classBDuplicate = (ClassB)formatter.Deserialize(stream);
            }
            Assert.AreSame(classBDuplicate.ClassCProperty.ClassAProperty.ClassBProperty, classBDuplicate);
        }

        [TestMethod]
        public void PreserveReferencesTestForClassC()
        {
            ClassA classA = new ClassA(new DateTime(1997, 1, 1, 0, 0, 0), 1.2m, "TestA", null);
            ClassB classB = new ClassB(new DateTime(1997, 2, 1, 0, 0, 0), 2.2m, "testB", null);
            ClassC classC = new ClassC(new DateTime(1997, 3, 1, 0, 0, 0), 3.2m, "testC", null);

            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            classC.ClassAProperty = classA;

            CustomFormatter formatter = new CustomFormatter();
            using (Stream stream = File.Open("test.txt", FileMode.Create, FileAccess.ReadWrite))
            {
                formatter.Serialize(stream, classC);
            }

            ClassC classCDuplicate;
            using (Stream stream = File.Open("test.txt", FileMode.Open, FileAccess.Read))
            {
                classCDuplicate = (ClassC)formatter.Deserialize(stream);
            }
            Assert.AreSame(classCDuplicate.ClassAProperty.ClassBProperty.ClassCProperty, classCDuplicate);
        }

        [TestMethod]

        public void ClassASimpleSerializationTest()
        {
            ClassA classA = new ClassA(new DateTime(1997, 1, 1, 0, 0, 0), 1.2m, "TestA", null);

            using (FileStream s = new FileStream("test.txt", FileMode.Create))
            {
                IFormatter f = new CustomFormatter();
                f.Serialize(s, classA);
            }

            string result = File.ReadAllText("test.txt");
            Assert.AreEqual(result, "TP_DL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|TP_DL.RefenrecesModel.ClassA|1|System.DateTime=DateTimeProperty=31.12.1996 23:00:00|System.Decimal=DecimalProperty=1,20|System.String=StringProperty=\"TestA\"|null=ClassBProperty=-1\n");
            
            File.Delete("test.txt");
        }

        [TestMethod]
        public void ClassAComplexSerializationTest()
        {
            ClassA classA = new ClassA(new DateTime(1997, 1, 1, 0, 0, 0), 1.2m, "TestA", null);
            ClassB classB = new ClassB(new DateTime(1997, 2, 1, 0, 0, 0), 2.2m, "testB", null);
            ClassC classC = new ClassC(new DateTime(1997, 3, 1, 0, 0, 0), 3.2m, "testC", null);

            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            classC.ClassAProperty = classA;

            using (FileStream s = new FileStream("test.txt", FileMode.Create))
            {
                IFormatter f = new CustomFormatter();
                f.Serialize(s, classB);
            }

            string result = File.ReadAllText("test.txt");
            Assert.AreEqual(result, "TP_DL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|TP_DL.RefenrecesModel.ClassB|1|System.DateTime=DateTimeProperty=31.01.1997 23:00:00|System.Decimal=DecimalProperty=2,20|System.String=StringProperty=\"testB\"|TP_DL.RefenrecesModel.ClassC=ClassCProperty=2\n"
                                   + "TP_DL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|TP_DL.RefenrecesModel.ClassC|2|System.DateTime=DateTimeProperty=28.02.1997 23:00:00|System.Decimal=DecimalProperty=3,20|System.String=StringProperty=\"testC\"|TP_DL.RefenrecesModel.ClassA=ClassAProperty=3\n"
                                   + "TP_DL, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null|TP_DL.RefenrecesModel.ClassA|3|System.DateTime=DateTimeProperty=31.12.1996 23:00:00|System.Decimal=DecimalProperty=1,20|System.String=StringProperty=\"TestA\"|TP_DL.RefenrecesModel.ClassB=ClassBProperty=1\n");
            
            File.Delete("test.txt");
        }

        [TestMethod]
        public void ClassADeserializationTest()
        {
            ClassA classA = new ClassA(new DateTime(1997, 1, 1, 0, 0, 0), 1.2m, "TestA", null);
            ClassB classB = new ClassB(new DateTime(1997, 2, 1, 0, 0, 0), 2.2m, "testB", null);
            ClassC classC = new ClassC(new DateTime(1997, 3, 1, 0, 0, 0), 3.2m, "testC", null);

            classA.ClassBProperty = classB;
            classB.ClassCProperty = classC;
            classC.ClassAProperty = classA;

            using (FileStream s = new FileStream("test.txt", FileMode.Create))
            {
                IFormatter f = new CustomFormatter();
                f.Serialize(s, classA);
            }

            using (FileStream s = new FileStream("test.txt", FileMode.Open))
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
            ClassA classA = new ClassA(new DateTime(1997, 1, 1, 0, 0, 0), 1.2m, "TestA", null);
            ClassB classB = new ClassB(new DateTime(1997, 2, 1, 0, 0, 0), 2.2m, "testB", null);
            ClassC classC = new ClassC(new DateTime(1997, 3, 1, 0, 0, 0), 3.2m, "testC", null);

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
            ClassA classA = new ClassA(new DateTime(1997, 1, 1, 0, 0, 0), 1.2m, "TestA", null);
            ClassB classB = new ClassB(new DateTime(1997, 2, 1, 0, 0, 0), 2.2m, "testB", null);
            ClassC classC = new ClassC(new DateTime(1997, 3, 1, 0, 0, 0), 3.2m, "testC", null);

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
