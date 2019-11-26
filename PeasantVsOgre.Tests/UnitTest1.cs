using System;
using Xunit;

namespace PeasantVsOgre.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void DoesCounteringWork()
        {
            //Arrange                   name, HP, attack, block, speed
            PlayerStatSettings peasant = new PlayerStatSettings("Peasant", 100, 0, 0, 10);
            PlayerStatSettings ogre = new PlayerStatSettings("Ogre", 100, 0, 0, 5);

            //Act
            peasant.Block();
            ogre.Attack();

            var peasantCounterVal = ogre.attack * 0.5; //reflect 50%
            var ogreCounterVal = peasant.attack * 0.25; //reflect 25%

            var expected = 0;

            Console.WriteLine("asdf");

            //Assert
            Assert.Equal(peasantCounterVal, expected);
        }
    }
}
