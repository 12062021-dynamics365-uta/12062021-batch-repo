using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Demo1.Tests
{
    internal class MockDbAccess : IDataBaseAccess
    {

        //public MockDbAccess()
        //{

        //}
        public List<Player> GetAllPlayers()
        {
            List<Player> players = new List<Player>();
            Player p1 = new Player()
            {
                Fname = "jimmy",
                Lname = "Jones",
                Losses = 2,
                Wins = 21
            };
            Player p2 = new Player()
            {
                Fname = "jammy",
                Lname = "Jones",
                Losses = 2,
                Wins = 21
            };
            Player p3 = new Player()
            {
                Fname = "jemmy",
                Lname = "Jones",
                Losses = 2,
                Wins = 21
            };
            players.Add(p1);
            players.Add(p2);
            players.Add(p3);

            return players;
        }
    }
}
