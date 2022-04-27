using System;
// using System.Collections.Generic;

namespace deck_of_cards
{
    public class Card
    {
        public string Name;
        public string Suit;
        public int Value;

        public Card(string n, string s, int v)
        {
            this.Name = n;
            this.Suit = s;
            this.Value = v;
        }

        public void Print()
        {
            Console.WriteLine($"This card is the {Name} of {Suit}, and it has a value of {Value}.");
        }
    }
}