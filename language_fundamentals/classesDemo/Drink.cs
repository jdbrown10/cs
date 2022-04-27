using System; //think of this as an import ()

namespace classesDemo
{  
    //need to make the class Public to let program.cs have access
    public class Drink
    {
        // Fields - a field is an attribute of the class. First you define them, and then you can make the constructors.

        //They all have to be public, too! Private is default if you don't specity.
        public string name;
        public string color;
        public bool icCarbonated;
        public double temperature;
        private int calories;

        //now that the fields have been defines, we make the constructors -- we need to say Public here, too
        public Drink(string n, string c, bool isC, double t, int cal)
        {
            name = n;
            color = c;
            icCarbonated = isC;
            temperature = t;
            calories = cal;
        }

        //they can be the same name and c# knows the difference because of the number of inputs
        public Drink(string n, string c, double t, int cal)
        {
            name = n;
            color = c;
            icCarbonated = true;
            temperature = t;
            calories = cal;
        }

        //methods-- make the class do something!
        //needs a scope ("public") and a return ("void")
        //the calories attribute is private, so the user can't modify calories unless they do it via this function. Prevents the user from doing something like "d1.calories = 10000" -- they'll have to add the calories only via the addSugar method
        public void addSugar(int amount)
        {
            this.calories += amount;
            Console.WriteLine($"Sugar was added, and now your calorie count is {this.calories}");
        }
    }
}