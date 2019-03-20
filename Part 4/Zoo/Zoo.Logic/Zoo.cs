using System.Collections.Generic;
using Zoo.Domain;

namespace Zoo.Logic
{
    public class Zoo
    {
        public Zoo()
        {
            Animals = new List<IAnimal>();
        }

        public IList<IAnimal> Animals { get; set; }

        public void AddAnimal(IAnimal animal)
        {
            Animals.Add(animal);
        }
    }
}
