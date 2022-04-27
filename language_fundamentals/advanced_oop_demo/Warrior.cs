using System;

namespace advanced_oop_demo
{
    //inheritance!! warrior is inheriting attributes from character
    public class Warrior : Character
    {
        public Warrior(string n) : base(n, 6, 80, 9, 5) {}
    // This is the warrior's specific deal damage
    public void DealDamage(Character target)
    {
        int amount = this.strength * -2;
        Console.WriteLine($"this.name strikes {target.name}, dealing {amount} damage!");
        target.ChangeHealth(amount);
        Console.WriteLine($"{target.name}'s health is now {target.Health}");
    }
    }


}