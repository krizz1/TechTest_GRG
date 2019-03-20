using System.Collections.Generic;

namespace Zoo.Domain
{
    public class Animal:IAnimal
    {
        public Animal()
        {
            Position = new Location();
        }

        public string Name { get; set; }
        public IList<MovementType> MovesBy { get; set; }
        public Location Position { get; set; }
        public int Hunger { get; set; }
        public bool IsHungry => Hunger > 50;
    }
}
