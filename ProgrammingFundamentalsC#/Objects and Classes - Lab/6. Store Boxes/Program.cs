using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _6._Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> itemBoxes = new List<Box>();
            double totalPrice = 0;

            while (true)
            {
                string command = Console.ReadLine();
                string[] parts = command.Split();

                if (command == "end")
                {
                    break;
                }

                string serialNumber = parts[0];
                string itemName = parts[1];
                int itemQuantity = int.Parse(parts[2]);
                double itemPrice = double.Parse(parts[3]);

                totalPrice = itemPrice * itemQuantity;

                Box box = new Box();

                box.SerialNumber = serialNumber;
                box.ItemName = itemName;
                box.ItemQuantity = itemQuantity;
                box.PriceForBox = itemPrice;
                box.TotalPrice = itemPrice * itemQuantity;

                itemBoxes.Add(box);
            }

            List<Box> sortedBox = itemBoxes.OrderBy(boxes => boxes.TotalPrice).ToList();
            sortedBox.Reverse();

            foreach (Box box in sortedBox)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.ItemName} - ${box.PriceForBox:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.TotalPrice:F2}");

            }
        }
    }
   
    class Box
    {


        public string SerialNumber { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public double PriceForBox { get; set; }
        public double TotalPrice { get; set; }
    }
}
