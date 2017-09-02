using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class Human {
            string name;
            int strength = 3;
            int intelligence = 3;
            int dexterity = 3;
            int health = 100;
            
            public Human(string humanName){
                name = humanName;
            }

            public Human(string humanName, int strength, int intelligence, int dexterity, int health){
                this.name = humanName;
                this.strength = strength;
                this.intelligence = intelligence;
                this.dexterity = dexterity;
                this.health = health;
            }

            private void attack(Human human){
                human.health -= (this.strength * 5);
            }
        }
    }
}
