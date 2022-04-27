using System;

namespace advanced_oop_demo
{
    public class Sorceror : Character, ICastMagic
    {
        //fields
        //special field for just the sorceror
        public int mana {get;set;}
        
        public Sorceror(string n) : base(n, 7, 60, 5, 10) 
        {
            mana = 200;
        }
    public void DealDamage(Character target)
    {
        int amount = intelligence * -2;
        Console.WriteLine($"{this.name} strikes {target.name} with a magic bolt, dealing {amount} damage!");
        target.ChangeHealth(amount);
        this.mana -= 10;
        Console.WriteLine($"{target.name}'s health is now {target.Health}");
        Console.WriteLine($"{this.name}'s mana is now {this.mana}");
    }
        public void castSpell() //we HAVE to call this castSpell because we are using the ICastMagic interface
    {
        this.mana -= 10;
        Console.WriteLine("You cast a spell!");
    }
    }

}