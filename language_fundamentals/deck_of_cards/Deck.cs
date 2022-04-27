using System;
using System.Linq;
using System.Collections.Generic;

namespace deck_of_cards
{
    public class Deck
    {
        public List<Card> Cards;

        public Deck()
        {
            this.Cards = new List<Card>
            {
                
            };
            MakeCards();
        }

        public void MakeCards()
        {
            //cards 2-10, king, queen, ace, jack - for each suit
            List<string> names = new List<string>();

            names.Add("Ace");
            names.Add("2");
            names.Add("3");
            names.Add("4");
            names.Add("5");
            names.Add("6");
            names.Add("7");
            names.Add("8");
            names.Add("9");
            names.Add("10");
            names.Add("Jack");
            names.Add("Queen");
            names.Add("King");

            List<string> suits = new List<string>();

            suits.Add("Hearts");
            suits.Add("Clubs");
            suits.Add("Spades");
            suits.Add("Diamonds");

            foreach (string suit in suits)
            {
                int counter = 1;
                foreach (string name in names)
                {
                    Card newCard = new Card($"{name}", $"{suit}", counter);
                    Cards.Add(newCard);
                    counter++;
                }
            }
        }
        

        public void ShuffleDeck()
        {
            Random rand = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                Card temp = Cards[i];
                int randvalue = rand.Next(0, Cards.Count);
                Cards[i] = Cards[randvalue];
                Cards[randvalue] = temp;
            }
            // var shuffle = Cards.OrderBy(item => rand.Next());
            // foreach (Card i in shuffle)
            // int index = 0;
            // {
            //     this.Cards[index] = i;
            //     Console.WriteLine(i.Name);
            //     index++;
            // }
            // this.Cards = shuffle;
            
        }

        public Card Deal()
        {
            Card temp = Cards[0];
            this.Cards.RemoveAt(0);
            return temp;
        }
    }

}
