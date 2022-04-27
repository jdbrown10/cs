using System;
using System.Collections.Generic;

namespace collections_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            //three basic arrays
            int[] FirstArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            string[] SecondArray = new string[] { "Tim", "Martin", "Nikki", "Sara" };

            bool[] ThirdArray = new bool[] { true, false, true, false, true, false, true, false, true, false };

            //list of flavors
            List<string> IceCream = new List<string>();

            IceCream.Add("Chocolate");
            IceCream.Add("Cherry Garcia");
            IceCream.Add("Strawberry");
            IceCream.Add("Mint Chocolate Chip");
            IceCream.Add("Chocolate Chip Cookie Dough");

            Console.WriteLine(IceCream.Count);
            Console.WriteLine(IceCream[2]);
            IceCream.RemoveAt(2);
            Console.WriteLine(IceCream.Count);

            //user info dictionary
            Dictionary<string, string> UserInfo = new Dictionary<string, string>();
            //Almost all the methods that exists with Lists are the same with Dictionaries

            for (int i = 0; i < SecondArray.Length; i++)
            {
                UserInfo.Add(SecondArray[i], IceCream[i]);
            }
            // UserInfo.Add("Tim", "Chocolate");
            // UserInfo.Add("Martin", "Cherry Garcia");
            // UserInfo.Add("Nikki", "Strawberry");
            // UserInfo.Add("Sara", "Mint Chocolate Chip");
            foreach (KeyValuePair<string, string> entry in UserInfo)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }
    }
}