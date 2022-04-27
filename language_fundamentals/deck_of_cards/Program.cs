using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Card koh = new Card("King", "Hearts", 13);
            koh.Print();

            Deck d1 = new Deck();
            Console.WriteLine(d1);

            //print all of the cards in the deck
            foreach (Card card in d1.Cards)
            {
                card.Print();
            }

            Console.WriteLine("=============");

            d1.ShuffleDeck();
            
            //print all of the cards in the deck
            foreach (Card card in d1.Cards)
            {
                card.Print();
            }
            
            Player p1 = new Player("Josh");

            p1.Draw(d1);
            p1.Draw(d1);
            p1.Draw(d1);

            foreach (Card card in p1.Hand)
            {
                Console.WriteLine("===============");
                Console.WriteLine("Drawing a card!");
                card.Print();
                Console.WriteLine("===============");
            }

            Console.WriteLine(p1.Discard(0).Name);
            Console.WriteLine(p1.Discard(0).Name);
            Console.WriteLine(p1.Discard(0).Name);
            Console.WriteLine(p1.Discard(0));
            

        }


    }
}