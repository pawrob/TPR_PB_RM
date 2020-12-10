using System;
using System.Runtime.Serialization;

namespace TP_DL.Objects
{
    public enum VehicleType
    {
        Cabriolet,
        Estate_car,
        Hatchback,
        Saloon,
        Small_car,
        Coupe,
        SUV,
        Van,
        Other
    }

    public enum FuelType
    {
        Petrol,
        Diesel,
        Electric,
        Hybrid,
        Other
    }

    public enum Transmission
    {
        Manual,
        Semi_automatic,
        Automatic,
    }


    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public int Horsepower { get; set; }
        public string Color { get; set; }
        public VehicleType VehicleType { get; set; }
        public FuelType FuelType { get; set; }
        public Transmission Transmission { get; set; }

        public Guid Id{ get; set; }

        public Car(string make, string model, string variant, int horsepower, string color, VehicleType vehicleType, FuelType fuelType, Transmission transmission)
        {
            Make = make;
            Model = model;
            Variant = variant;
            Horsepower = horsepower;
            Color = color;
            VehicleType = vehicleType;
            FuelType = fuelType;
            Transmission = transmission;
            Id = new Guid();
        }


        public override bool Equals(object obj)
        {
            return obj is Car car &&
                   Make == car.Make &&
                   Model == car.Model &&
                   Variant == car.Variant &&
                   Horsepower == car.Horsepower &&
                   Color == car.Color &&
                   VehicleType == car.VehicleType &&
                   FuelType == car.FuelType &&
                   Transmission == car.Transmission;
        }

        public override string ToString()
        {
            return "Make: " + Make + "Model: " + Model + "Variant: " + Variant + "Horsepower: " + Horsepower + "Color: " + Color
                    + "VehicleType: " + VehicleType + "FuelType: " + FuelType + "Transmission: " + Transmission;

        }


    }
}
