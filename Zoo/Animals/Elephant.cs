using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    public class Elephant : IAnimal
    {
        private int healthPoints;
        private bool canElephantWalk = true;

        public Elephant(int healthPoints)
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
                if (HealthPoints > 70)
                {
                    canElephantWalk = true;
                }
            }
            else
            {
                HealthPoints = 100;
                Console.WriteLine("Elephant is full.");
            }
            Console.WriteLine($"Health of elephant is {HealthPoints}");
        }

        public void GettingHungry()
        {
            Random random = new Random();

            int randomNumber = random.Next(0, 21);

            if (canElephantWalk)
            {
                HealthPoints -= randomNumber;

                Console.WriteLine($"Health of elephant is {HealthPoints}");

                if (HealthPoints < 70)
                {
                    canElephantWalk = false;
                    Console.WriteLine("The elephant can't walk!");
                }
                else
                {
                    canElephantWalk = true;
                }
            }
            else
            {
                HealthPoints = 0;
                Console.WriteLine("Sorry, elephant is already dead..");
            }

        }

        public bool IsAnimalDead()
        {
            return healthPoints < 70;
        }
    }
}
