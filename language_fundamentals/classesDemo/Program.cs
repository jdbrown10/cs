using System;

namespace classesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");
            //"drink" is itself a new data type that we've created. and it's already imported because of the namespace.
            Drink d1 = new Drink("Coffee", "brown", false, 95.5, 200);

            Console.WriteLine($"I am drinking {d1.name}");

            //c# knows to use the second Drink constructor in Drink.cs because this does not input a bool-- so isCarbonated will automatically be set to true
            Drink d2 = new Drink("Coke", "brown", 32.6, 200);

            Console.WriteLine(d2.icCarbonated);

            // Console.WriteLine(d1.calories);
            d1.addSugar(100);
            // Console.WriteLine(d1.calories);
        }
    }
}