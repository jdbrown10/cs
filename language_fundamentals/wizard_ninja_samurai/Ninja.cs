using System; 

namespace wizard_ninja_samurai
{
    public class Ninja : Human
    {
        // Fields



        public Ninja(string n) : base(n, 3, 3, 175, 100){}
        
        public override int Attack(Human target)
        {
            int damage;
            Random rand = new Random();
            if (rand.Next(0, 5) == 3)
            {
                damage = (5*this.Dexterity) + 10;
                Console.WriteLine("It's a critical hit!");
            } else
            {
                damage = (5*this.Dexterity);
            }
            target.Health -= damage;
            Console.WriteLine($"Damaged {target.Name} by {damage}!");
            return target.Health;
        }

        public void Steal(Human target)
        {
            target.Health -= 5;
            this.health += 5;
            Console.WriteLine($"{this.Name} stole 5 health from {target.Name}!");
            Console.WriteLine($"{this.Name} has {this.health} health.");
            Console.WriteLine($"{target.Name} has {target.Health} health.");
        }
    }

}
