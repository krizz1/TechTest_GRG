using Zoo.Domain;

namespace Zoo.Domain
{
    public static class AnimalExtensions
    {
        public static void Move(this Animal animal, int byX, int byY, int byZ)
        {
            animal.Position.X += byX;
            animal.Position.Z += byZ;

            if (animal.MovesBy == MovementType.Fly)
            {
                //In this instance we're using the y axis to depict vertical movement
                animal.Position.Y += byY;
            }
        }

        public static void Eat(this Animal animal, int qty)
        {
            animal.Hunger -= qty;

            if (animal.Hunger < 0)
            {
                animal.Hunger = 0;
            }
        }
    }
}
