using System;
using System.Collections.Generic;
using Xunit;

namespace Rock_Paper_Scissors_Demo1.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            //Mapper mapper = new Mapper();
            MockDbAccess mockDbAccess = new MockDbAccess();
            GamePlayLogic gpl = new GamePlayLogic(mockDbAccess);


            // Act
            List<Player> players = gpl.GetAllPlayers();

            // Assert
            Assert.Equal(3,players.Count);

        }
    }
}
