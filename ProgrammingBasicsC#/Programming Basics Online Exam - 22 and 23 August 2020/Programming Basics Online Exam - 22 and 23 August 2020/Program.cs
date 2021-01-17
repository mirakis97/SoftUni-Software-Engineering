using System;

namespace Programming_Basics_Online_Exam___22_and_23_August_2020
{
    class Program
    {
        static void Main(string[] args)
        {
            const double dollarLev = 1.57;

            double processor = double.Parse(Console.ReadLine());
            double videoCard = double.Parse(Console.ReadLine());
            double oneRam = double.Parse(Console.ReadLine());
            double picesOfRam = double.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            double processorInLeva = processor * dollarLev;
            double videoCardInLeva = videoCard * dollarLev;
            double oneRamInLeva = oneRam * dollarLev;
            double totalRam = picesOfRam * oneRamInLeva;

            double priceOfProcessorWithDiscount = processorInLeva - (processorInLeva * discount);
            double priceOfVideoCardWithDiscount = videoCardInLeva - (videoCardInLeva * discount);

            double totalPrice = priceOfProcessorWithDiscount + priceOfVideoCardWithDiscount + totalRam;

            Console.WriteLine($"Money needed - {totalPrice:f2} leva.");

        }
    }
}
