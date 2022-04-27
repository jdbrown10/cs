using System;

namespace advanced_oop_demo
{
    //use the word abstract here to make it so that a user cannot make a character -- the character class is now representational instead of directly tangible.
    public abstract class Character
    {
        //attributes
        public string name;
        public int level;
        private int health;

        //use a capital letter for the special attributes
        public int Health{get {return health;}}
        public int strength;
        public int intelligence;
        
        //constructor

        public Character(string n, int l, int h, int s, int i)
        {
            name = n;
            level = l;
            health = h;
            strength = s;
            intelligence = i;
        }

        //methods
        public void showStats()
        {
            Console.WriteLine($"Name:      {this.name}");
            Console.WriteLine($"Level:     {this.level}");
            Console.WriteLine($"Health:    {this.health}");
            Console.WriteLine($"Str:       {this.strength}");
            Console.WriteLine($"Int:       {this.intelligence}");
        }

        //"virtual" here allows us to override it in the sub-classes
        public void DealDamage (Character target, int amount)
        {
            Console.WriteLine($"{this.name} attacked {target.name}, dealing {amount} damage");
            target.health -= amount;
            Console.WriteLine($"{target.name}'s health: {target.health}");
        }

        //this method can be called upon in the inherited classes to change health-- they don't have access to it otherwise because it's a private attribute
        public void ChangeHealth(int amount)
        {
            this.health += amount;
        }
    }
}