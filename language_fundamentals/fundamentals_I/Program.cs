using System;

namespace fundamentals_I
{
    class Program
    {
        static void Main(string[] args)
        {
            // loop from 1 to 255
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("=================");
            // print values from 1 to 100 that are divisible by 3 or 5, but not both
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 != 0)
                {
                    Console.WriteLine(i);
                }
                else if (i % 3 != 0 && i % 5 == 0)
                {
                    Console.WriteLine(i);
                }
            }
            
            // print values from 1 to 100 that are divisible by 3 or 5, and "fizzbuzz" for both
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 != 0)
                {
                    Console.WriteLine(i);
                }
                else if (i % 3 != 0 && i % 5 == 0)
                {
                    Console.WriteLine(i);
                }
                else if (i % 15 == 0)
                {
                    Console.WriteLine("fizzbuzz");
                }
            }
        }
    }
}
