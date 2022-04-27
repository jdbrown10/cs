using System;
using System.Collections.Generic;

namespace puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomArray();
            TossCoin();
            ShuffleNames();
        }

        //Random Array
        public static int[] RandomArray()
        {

            int[] Array = new int[10];

            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {

                Array[i] = rand.Next(5, 26);

                //have to Console.WriteLine here to see the contents of the array
                Console.WriteLine(Array[i]);
            }
            return Array;
        }

        //Coin Flip
        public static string TossCoin()
        {
            Console.WriteLine("Tossing a Coin!");
            Random rand = new Random();
            int num = rand.Next(0, 2);
            if (num == 0)
            {
                Console.WriteLine("Tails");
                string result = "Tails";
                return result;
            }
            else
            {
                Console.WriteLine("Heads");
                string result = "Heads";
                return result;
            }
        }

        //Names
        public static List<string> ShuffleNames()
        {
            List<string> names = new List<string>();
            names.Add("Todd");
            names.Add("Tiffany");
            names.Add("Charlie");
            names.Add("Geneva");
            names.Add("Sydney");
            
            Random rand = new Random();
            

            for (int i = 0; i < names.Count; i++)
            {
                string temp = names[i];
                int random = rand.Next(0, names.Count);
                names[i] = names[random];
                names[random] = temp;
            }

            return names;
            
        }

    }
}