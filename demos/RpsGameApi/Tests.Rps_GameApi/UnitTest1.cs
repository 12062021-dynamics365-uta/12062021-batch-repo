using DataBaseAccess1;
using GamePlayLogic1;
using Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests.Rps_GameApi
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //arrange
            //because of Dependency Inversion, you can create a rando class that implements
            //the correct interface required in the constructor of the class under test.
            IDatabaseAccess mockDbAccess = new MockDatabaseAccess();
            //THEN, create an instnce of the class under test with the mockclass as a dependency
            //this allows you to 
            GamePlayLogic gpl = new GamePlayLogic(mockDbAccess);

            //act
            List<Player> result = gpl.GetAllPlayers();

            //assert
            Assert.Equal(3, result.Count);
            Assert.True(result[0].Fname == "jimmy");
        }
    }
}
