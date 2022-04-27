using System; 

namespace wizard_ninja_samurai
{
    public class Wizard : Human
    {
        // Fields for Wizard
        
        public Wizard(string n) : base(n, 3, 25, 3, 50){}
        
        public override int Attack(Human target)
        {
            int damage = 5*this.Intelligence;
            target.Health -= damage;
            this.health += damage;
            Console.WriteLine($"Damaged {target.Name} by {damage} and healed {this.Name} by {damage}!");
            return target.Health;
        }

        public int Heal(Human target)
        {
            int amount = this.Intelligence*10;
            target.Health += amount;
            Console.WriteLine($"{target.Name} healed by {amount}!");
            return amount;
        }
    }


}
