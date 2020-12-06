using System;
using TP_DL;
using TP_DL.Objects;


namespace TP_UnitTests
{
    public class DataManualFiller : IDataFiller
    {

        public DataManualFiller(){}

        public void InsertData(DataContext dataContext)
        {
            dataContext.Clients.Add(new Client("John", "Doe", 000000000, Guid.NewGuid()));
/*            dataContext.Clients.Add(new Client("Jack", "Karabinczyk", 213721151, Guid.NewGuid())); 
            dataContext.Clients.Add(new Client("Peter", "Parker", 123456789, Guid.NewGuid()));
            dataContext.Cars.Add(Guid.NewGuid(),new Car("Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual));*/
        }
    }
}
