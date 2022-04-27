using System;

namespace basic_13_in_class
{
    class Program
    {
        static void Main(string[] args)
        {
            //this doesn't actually print the contents of the array
            Console.WriteLine(OddArray()); 
        }
        public static int[] OddArray()
        {
            // Write a function that creates, and then returns, an array that contains all the odd numbers between 1 to 255. 
            // When the program is done, this array should have the values of [1, 3, 5, 7, ... 255].

            int[] OddArray = new int[128]; // the list only has indexes of 0-127
            
            int index = 0;

            for (int i = 0; i < 256; i++)
            {
                if (i % 2 == 1)
                {
                    OddArray[index] = i;

                    //have to Console.WriteLine here to see the contents of the array
                    Console.WriteLine(OddArray[index]);
                    index++;
                }
            }
            return OddArray;
        }
    }
}