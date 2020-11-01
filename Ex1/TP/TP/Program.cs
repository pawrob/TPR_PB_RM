using System;
using TP.Objects;

namespace TP
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c1 = new Client("karol","Wojtyła",111111);
            Guid g = Guid.NewGuid();
            Car Car1 = new Car(g, "Alfa Romeo", "Brera", "Italia Independent", 210, "Matte Grey", VehicleType.Coupe, FuelType.Diesel, Transmission.Manual);
            Stock s1 = new Stock(Car1, 100);

            Console.WriteLine(Car1);
            Console.WriteLine(s1);

        }
    }
}
