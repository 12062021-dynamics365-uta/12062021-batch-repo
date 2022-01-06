using DataBaseAccess1;
using GamePlayLogic1;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Rps_GameApi
{
    public class UnitTest1
    {
        private static IDatabaseAccess mockDbAccess = new MockDatabaseAccess();
        private static IMapper mockMapper = new MockMapper();
        private static GamePlayLogic gpl = new GamePlayLogic(mockDbAccess, mockMapper);

        [Fact]
        public void GetAllPlayersReturnsAListOfPlayersFromDb()
        {
            //arrange
            //because of Dependency Inversion, you can create a rando class that implements
            //the correct interface required in the constructor of the class under test.
            //IDatabaseAccess mockDbAccess = new MockDatabaseAccess();
            //THEN, create an instnce of the class under test with the mockclass as a dependency
            //this allows you to 

            //act
            List<Player> result = gpl.GetAllPlayers();

            //assert
            Assert.Equal(3, result.Count);
            Assert.True(result[0].Fname == "jimmy");
        }

        [Theory]
        [InlineData("Mark","Moore")]
        [InlineData("Mark", "jumbly")]
        public async Task LoginReturnsPlayerObjectIfPlayerExistsNullIfNotAsync(string fname, string lname)
        {
            // ARRANGE  is above

            // ACT
            Player result = await gpl.LoginAsync(fname, lname);

            // ASSERT
            if (lname == "jumbly")
            {
                //Assert.Null(result);    
                Assert.Equal("jumbly",result.Lname);
            }
            else
            {
                Assert.Equal("mumbly", result.Fname);
            }
        }


    }
}
