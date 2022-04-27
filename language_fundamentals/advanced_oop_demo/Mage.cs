using System;

namespace advanced_oop_demo
{
    public class Mage : Character, ICastMagic
    {
        //fields
        //special field for just the mage
        public int mana {get;set;} //because we are using ICastMagic, Mage has to have a mana attribute. This makes it so that all of the magic-using characters MUST follow the same conventions.
        
        public Mage(string n) : base(n, 7, 65, 6, 9) 
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