using System;
using System.Collections.Generic;

namespace advanced_oop_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");
            // since character is abstract, we cannot do this:
            // Character myCharacter = new Character("InsertNameHere", 5, 50, 8, 5);
            // Character myCharacter2 = new Character("character 2", 7, 70, 7, 2);
            // Character myCharacter3 = new Character("character 3", 5, 30, 4, 10);

            // Console.WriteLine(myCharacter.name);

            //but we CAN make warriors and sorcerors, because they are their own thing.
            //we do this for security, because we don't want users to be able to make generic characters that don't have a class.

            Warrior w1 = new Warrior ("WarriorName");
            Warrior w2 = new Warrior ("WarriorName");

            Console.WriteLine(w1.strength);

            Sorceror s1 = new Sorceror ("SorcerorName");
            Mage m1 = new Mage ("Dr. Mage");


            //polymorphism allows you to treat both warriors and sorcerers as Character type data, because they have that class in common at their base level
            List<Character> allCharacters = new List<Character>();

            allCharacters.Add(w1);
            allCharacters.Add(w2);
            allCharacters.Add(s1);
            allCharacters.Add(m1);


            Console.WriteLine(s1.intelligence);

            w1.showStats();
            s1.showStats();

            w1.DealDamage(s1);
            s1.DealDamage(w1);

            //the ICastMagic interface binds all of the magic users together as one common group.

            //you could make a list of all of them like this...
            List<ICastMagic> allMagicUsers = new List<ICastMagic>();

            //and then add them to the list like this!
            foreach(Character c in allCharacters)
            {
                //Which characters have the ability to cast magic?
                if (c is ICastMagic)
                {
                    allMagicUsers.Add((ICastMagic)c); // we have to typecast the character as an ICastMagic data type in order to add it to the new list
                }
            }

            foreach (Character c in allMagicUsers)
            {
                Console.WriteLine(c.name);
            }

            //You can't do this because of encapsulation - warriors don't have mana!!
            //Console.WriteLine(w1.mana);

            //Four pillars of OOP
            //Inheritance - having a parent class and some children that take attributes from the parent and make our coding life so much easier

            //Polymorphism - many forms - all things that come from the same base are still related to each other. 

            //Encapsulation - an object is able to maintain some kind of private state. we have methods in our classes that are only accessible to that class. Nothing outside of the class can touch or use these methods. (i.e., a warrior cannot make a sorcer cast a spell.)

            //Abstraction - Abstraction makes it so that only data that the user needs to see is visible to them. we can select specific pieces of data from our data pool, but others are hidden from us. i.e., pokemon EVs and IVs exist but in the older games there was no way to look at them. This makes things as streamlined as possible for our users while still retaining data we need to operate our classes.
        }
    }
}