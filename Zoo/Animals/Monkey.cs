using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    public class Monkey : IAnimal
    {
        private int healthPoints;

        public Monkey(int healthPoints)
        {
            this.healthPoints = healthPoints;
        }

        public int HealthPoints
        {
            get { return healthPoints; }
            private set
            {
                if (value >= 0 && value <= 100)
                {
                    healthPoints = value;
                }
            }
        }

        public void Eating()
        {
            Random random = new Random();

            int randomNumber = random.Next(5, 26);

            if (HealthPoints + randomNumber <= 100)
            {
                HealthPoints += randomNumber;
            }
            else
            {
                HealthPoints = 100;
                Console.WriteLine("Monkey is full.");
            }
            Console.WriteLine($"Health of monkey is {HealthPoints}");
        }

        public void GettingHungry()
        {
            Random random = new Random();

            int randomNumber = random.Next(0, 21);

            if (HealthPoints - randomNumber < 40)
            {
                Console.WriteLine("Sorry, monkey is already dead..");
                HealthPoints = 0;
            }
            else
            {
                HealthPoints -= randomNumber;
                Console.WriteLine($"Health of monkey is {HealthPoints}");
            }

        }

        public bool IsAnimalDead()
        {
            return healthPoints < 40;
        }
    }
}
