using System.Collections.Generic;

namespace Zoo.Domain
{
    public class Duck: Animal,IAnimal
    {
        public Duck()
        {
            base.Name = "Duck";
            base.MovesBy = new List<MovementType>() {
                MovementType.Walk,
                MovementType.Swim,
                MovementType.Fly
            };
        }
    }
}
