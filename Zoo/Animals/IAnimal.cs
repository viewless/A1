using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    public interface IAnimal
    {
        public void GettingHungry();
        public void Eating();
        public bool IsAnimalDead();

    }
}
