using System;
using System.Collections.Generic;
using Zoo.Animals;


namespace Zoo
{
    public class Zoo
    {
        static void Main(string[] args)
        {
            Lion lion = new Lion(100);
            Elephant elephant = new Elephant(100);
            Monkey monkey = new Monkey(100);
            Monkey monkey2 = new Monkey(100);
            Lion lion2 = new Lion(100);

            List<IAnimal> animals = new List<IAnimal> { lion, monkey, lion2, monkey2, elephant };

            Console.WriteLine("Use \"f\" to feed the animals and \"h\" to make the animals starv.");
            Console.WriteLine("Use \"s\" to stop the program.");
            string input = Console.ReadLine();

            while (input != "s")
            {
                if (input == "f")
                {
                    foreach (var animal in animals)
                    {
                        animal.Eating();
                    }
                }
                else if (input == "h")
                {
                    foreach (var animal in animals)
                    {
                        animal.GettingHungry();
                    }
                }
                input = Console.ReadLine();
            }

            AliveAnimalsCount(animals);
        }

        private static void AliveAnimalsCount(List<IAnimal> animals)
        {
            int countAnimalsAlive = 0;

            foreach (var animal in animals)
            {
                if (animal.IsAnimalDead() == false)
                {
                    countAnimalsAlive++;
                }
            }

            Console.WriteLine("Animals alive: " + countAnimalsAlive);
        }
    }
}
