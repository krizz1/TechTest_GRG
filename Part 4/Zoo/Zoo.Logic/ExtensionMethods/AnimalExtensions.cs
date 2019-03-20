using Zoo.Domain;

public static class AnimalExtensions
{
    public static void Walk(this IAnimal animal, int byX, int byZ)
    {
        animal.Position.X += byX;
        animal.Position.Z += byZ;
    }

    public static void Swim(this IAnimal animal, int byX, int byY, int byZ)
    {
        animal.Position.X += byX;
        animal.Position.Z += byZ;

        if (animal.MovesBy.Contains(MovementType.Swim))
        {
            //In this instance we're using the y axis to depict vertical movement
            animal.Position.Y += byY;

            if (animal.Position.Y > 0)
            {
                //Assume 0 is sea level and
                //(for this purposes of this application)
                //fish can't fly
                animal.Position.Y = 0;
            }
        }
    }

    public static void Fly(this IAnimal animal, int byX, int byY, int byZ)
    {
        animal.Position.X += byX;
        animal.Position.Z += byZ;

        if (animal.MovesBy.Contains(MovementType.Fly))
        {
            //In this instance we're using the y axis to depict vertical movement
            animal.Position.Y += byY;

            if (animal.Position.Y < 10)
            {
                //Assume 0 is sea level and
                //(for this purposes of this application)
                //birds can't dive lower than a depth of 10 into water
                animal.Position.Y = 0;
            }
        }
    }
    
    public static void Eat(this IAnimal animal, int qty)
    {
        {
            animal.Hunger -= qty;

            if (animal.Hunger < 0)
            {
                animal.Hunger = 0;
            }
        }
    }
}