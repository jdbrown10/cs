using System; 

namespace wizard_ninja_samurai
{
    public class Samurai : Human
    {
        // Fields for Human

        public Samurai(string n) : base(n, 3, 3, 3, 200){}
        
        public override int Attack(Human target)
        {
            if (target.Health < 50)
            {
                target.Health = 0;
                return target.Health;
            } else
            {
                this.Attack(target);
                return target.Health;
            }
        }

        public void Meditate()
        {
            Console.WriteLine($"{this.Name} is meditating...");
            this.health = 200;
            Console.WriteLine($"{this.Name} has been restored to full health!");
        }
    }


}
