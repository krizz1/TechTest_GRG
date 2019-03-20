using System.Collections.Generic;

namespace Zoo.Domain
{
    public interface IAnimal
    {
        string Name { get; set; }
        IList<MovementType> MovesBy { get; set; }
        Location Position { get; set; }
        int Hunger { get; set; }
        bool IsHungry { get; }
    }
}
