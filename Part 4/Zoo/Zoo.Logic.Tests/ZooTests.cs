using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Zoo.Domain;

namespace Zoo.Logic.Tests
{
    [TestFixture]
    public class ZooTests
    {
        private Zoo londonZoo;

        [SetUp]
        public void Setup()
        {
            londonZoo = new Zoo();

            londonZoo.AddAnimal(new Animal() {Name = "Monkey", MovesBy = new List<MovementType>() {MovementType.Walk}});
            londonZoo.AddAnimal(new Animal() { Name = "Dolphin", MovesBy = new List<MovementType>() { MovementType.Swim } });
            londonZoo.AddAnimal(new Animal() { Name = "Bat", MovesBy = new List<MovementType>() { MovementType.Fly, MovementType.Walk } });
            londonZoo.AddAnimal(new Animal() { Name = "Penguin", MovesBy = new List<MovementType>() { MovementType.Walk, MovementType.Swim } });
            londonZoo.AddAnimal(new Duck());
        }
        
        [Test,TestCaseSource(typeof(MovementTestData),nameof(MovementTestData.TestCases))]
        public void MoveAnimals(MovementType movementType, int byX, int byZ, int byY)
        {
            foreach (IAnimal animal in londonZoo.Animals)
            {
                switch (movementType)
                {
                    case MovementType.Walk:
                        animal.Walk(byX, byZ);
                        break;
                    case MovementType.Swim:
                        animal.Swim(byX, byY, byZ);
                        break;
                    case MovementType.Fly:
                        animal.Fly(byX, byY, byZ);
                        break;
                }
            }

            Assert.IsTrue(Checks_Walk() && Checks_Swim() && Checks_Fly());
        }

        /// <summary>
        /// Check if any animals position hasn't changed as expected for walkers
        /// </summary>
        /// <returns>True if the test passes</returns>
        private bool Checks_Walk()
        {
            //Check animals that can only walk
            return !londonZoo.Animals.Any(x => x.MovesBy.Contains(MovementType.Walk) &&
                (x.MovesBy.Count == 1 && x.Position.Y != 0) &&
                (x.Position.X == 0 || x.Position.Z == 0));
        }

        /// <summary>
        /// Check if any animals position hasn't changed as expected for swimmers
        /// </summary>
        /// <returns>True</returns>
        private bool Checks_Swim()
        {
            //Check animals that can only walk
            return !londonZoo.Animals.Any(x => x.MovesBy.Contains(MovementType.Swim) &&
                (x.MovesBy.Count == 1 && x.Position.Y <= 0) &&
                (x.Position.X == 0 || x.Position.Z == 0));
        }

        /// <summary>
        /// Check if any animals position hasn't changed as expected for swimmers
        /// </summary>
        /// <returns>True</returns>
        private bool Checks_Fly()
        {
            //Check animals that can only walk
            return !londonZoo.Animals.Any(x => x.MovesBy.Contains(MovementType.Fly) &&
                (x.MovesBy.Count == 1 && x.Position.Y >= 0) &&
                (x.Position.X == 0 || x.Position.Z == 0));
        }

        public class MovementTestData
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(MovementType.Walk, 100,100,0)
                        .SetName("AnimalLogic_Movement_Walk")
                        .SetCategory("CI");

                    yield return new TestCaseData(MovementType.Swim, 100, 100, -100)
                        .SetName("AnimalLogic_Movement_Swim")
                        .SetCategory("CI");

                    yield return new TestCaseData(MovementType.Fly, 100, 100, 100)
                        .SetName("AnimalLogic_Movement_Fly")
                        .SetCategory("CI");
                }
            }
        }
    }
}
