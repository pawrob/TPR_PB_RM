using System;
using System.Collections.Generic;
using System.Text;
using Model;


namespace WPF_Test
{
    public class InitData
    {
        public Random random = new Random();

        public List<MyProduct> myProducts { get; set; }

        public InitData()
        {
            // myProducts.add((random.Next(10000), string name, string productNumber, string color, short safetyStockLevel, decimal standardCost, string size, System.Nullable<decimal> weight)
            myProducts = new List<MyProduct>();
            MyProduct p1 = new MyProduct(random.Next(10000), "Bike Fast", "XX-2115", "Red", 21, 210.2m, "standard", 8.2m);
            MyProduct p2 = new MyProduct(random.Next(10000), "Pedal", "AS-2138", "Gray", 5, 30.5m, "small", 2.4m);
            MyProduct p3 = new MyProduct(random.Next(10000), "Monocycle", "XR-1468", "Purple", 13, 94.2m, "standard", 6.3m);
            MyProduct p4 = new MyProduct(random.Next(10000), "Wheel", "AC-3333", "Black", 30, 30.2m, "standard", 1.2m);
            MyProduct p5 = new MyProduct(2137, "Motorbike Fast", "XY-2137", "Blue", 11, 1210.2m, "enormous", 48.3m);

            myProducts.Add(p1);
            myProducts.Add(p2);
            myProducts.Add(p3);
            myProducts.Add(p4);
            myProducts.Add(p5);
        }
        
    }
}
