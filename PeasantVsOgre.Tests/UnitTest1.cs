using System;
using Xunit;

namespace PeasantVsOgre.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void DoesAttackAndBlockPersistThroughturns()
        {
            //Arrange                   name, HP, attack, block, speed
            PlayerStatSettings peasant = new PlayerStatSettings("Peasant", 100, 0, 0, 10);
            PlayerStatSettings ogre = new PlayerStatSettings("Ogre", 100, 0, 0, 5);

            //Act
            ogre.Block();

            ogre.Attack();
            ogre.BlockReset();

            var expected = 0;

            //Assert
            Assert.Equal(ogre.block, expected);
        }
    }
}
