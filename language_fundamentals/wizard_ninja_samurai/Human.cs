using System; 

namespace wizard_ninja_samurai
{
    public class Human
    {
        // Fields for Human
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        protected int health;

        public int Health
        {
            get{return health;}
            set{health=value;}
        }

        // add a public "getter" property to access health

        public void GetHealth()
        {
            Console.WriteLine(this.health);
        }

        // Add a constructor that takes a value to set Name, and set the remaining fields to default values
        // not being used!
        // public Human(string n)
        // {
        //     Name = n;
        //     Strength = 3;
        //     Intelligence = 3;
        //     Dexterity = 3;
        //     health = 100;
        // }

        // Add a constructor to assign custom values to all fields
        public Human(string n, int s, int i, int d, int h)
        {
            Name = n;
            Strength = s;
            Intelligence = i;
            Dexterity = d;
            health = h;
        }

        // Build Attack method
        public virtual int Attack(Human target)
        {
            target.health -= 5*this.Strength;
            return target.health;
        }
    }


}
