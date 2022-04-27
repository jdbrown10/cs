using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    public class Player
    {
        //attributes
        public List<Card> Hand;

        public string Name;

        public Player(string n)
        {
            Name = n;
            this.Hand = new List<Card>
            {

            };
        }

        //Give the Player a draw method of which:
        //draws a card from a deck
        //adds it to the player's hand
        //and returns the Card
        public Card Draw(Deck d) //pass in a deck to the function
        {
            Card temp = d.Cards[0]; // store the first card in the deck as a temp
            this.Hand.Add(d.Cards[0]); //add the first card in the deck to this.hand
            d.Cards.RemoveAt(0); //remove the first card in the deck from the deck
            return temp; //return temp to return the card that was drawn
        }

        //Give the Player a discard method which...
        //discards the Card at the specified index from the player's hand 
        //and returns this Card or null if the index does not exist.
        public Card Discard(int i)
        {
            //there's no way to see if the index is equal to null, so we need to see if the hand is empty OR if the index is too high 
            if (this.Hand.Count < 1 || this.Hand.Count < i + 1)
            {
                Console.WriteLine("That card doesn't exist!");
                return null;
            }
            else
            {
                Card temp = this.Hand[i];
                this.Hand.RemoveAt(i);
                return temp;
            }
        }

        //how do you make a function that can return two different data types (null or card)?
    }
}