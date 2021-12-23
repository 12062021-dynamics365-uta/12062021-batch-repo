using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Rock_Paper_Scissors_Demo1.Tests
{
    public class UnitTest1
    {
        [Fact]// FACT is for a single test.
        public void GetAllPlayersReturnsListofThreePlayers()// call the test something desciptive to its actions.
        {
            // Arrange - set up the envvironment. includes mock classes and dependencies.
            MockDbAccess mockDbAccess = new MockDbAccess();
            GamePlayLogic gpl = new GamePlayLogic(mockDbAccess);

            // Act - complete the action oyou will be doing for the test.
            List<Player> players = gpl.GetAllPlayers();

            // Assert - assert that the results are what you expected.
            Assert.Equal(3.2001, 3.2000, 3);
            Assert.StrictEqual("jemmy", players[2].Fname);
            Assert.IsType<Player>(players[0]);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData("two")]
        public void GetAllPlayersReturnsListOfPlayersWithLastNameContainingOne(object n)
        {
            // Arrange
            MockDbAccess mockDbAccess = new MockDbAccess();
            GamePlayLogic gpl = new GamePlayLogic(mockDbAccess);

            // Act
            List<Player> players = gpl.GetAllPlayers();

            // use the object class method GetType() to get the data type of the object 
            // if the type is int, then check how many losses...
            if (typeof(int) == n.GetType())
            {
                Assert.Equal(2, players[(int)n].Losses);
            }
            else// otherwise verify that the type is a string, which is expected.
            {
                Assert.True(typeof(string) == n.GetType());
            }
        }


        // using 'MemberData' to call the test with 
        // create an IEnumberable of type object[].
        // assign a list of type object[] to it.
        // each element of thelist is an onject array. the array is the suite of arguments to be sent to the test on each run.
        // below, each object array only has 1 element, a Player.
        public static IEnumerable<object[]> players => new List<object[]>
        {
          new object[]{ new Player() { Fname = "jimmy", Lname = "Jones", Wins = 2, Losses = 21 },1 } ,
          new object[]{ new Player() { Fname = "jammy", Lname = "Jones", Wins = 2, Losses = 21 },2 } ,
          new object[]{ new Player() { Fname = "jemmy", Lname = "Jones", Wins = 2, Losses = 21 },3 } ,
        };

        /// <summary>
        /// In this test we will take the n param to know which Player to look for.
        /// </summary>
        /// <param name="p"></param>
        /// <param name="n"></param>
        [Theory]
        [MemberData(nameof(players))]
        public void PlayersListHasCorrectPlayers(Player p, int n)
        {
            // Arrange - set up the envvironment. includes mock classes and dependencies.
            MockDbAccess mockDbAccess = new MockDbAccess();
            GamePlayLogic gpl = new GamePlayLogic(mockDbAccess);

            // Act - complete the action oyou will be doing for the test.
            List<Player> players = gpl.GetAllPlayers();

            switch (n)
            {
                case 1:
                    // these asserts will query the players array to pull out the name we know is there.
                    // Then it will compare the Fname to the Fname of the param Player.
                    Assert.Equal(p.Fname, players.Where(x => x.Fname == "jimmy").FirstOrDefault().Fname);
                    break;
                case 2:
                    Assert.Contains(p.Fname, players.Where(x => x.Fname == "jammy").FirstOrDefault().Fname);
                    break;
                case 3:
                    Assert.Contains(p.Fname, players.Where(x => x.Fname == "jemmy").FirstOrDefault().Fname);
                    break;
                default:
                    break;

                    //testing auto save. 

            }
        }



    }//EoC
}//EoN
