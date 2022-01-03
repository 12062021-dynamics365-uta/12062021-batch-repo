using DataBaseAccess1;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Rps_GameApi
{
    internal class MockDatabaseAccess : IDatabaseAccess
    {
        public List<Player> GetAllPlayers()
        {
            List<Player> players = new List<Player>();
            Player p1 = new Player()
            {
                Fname = "jimmy",
                Lname = "Junes",
                Losses = 2,
                Wins = 21
            };
            Player p2 = new Player()
            {
                Fname = "jammy",
                Lname = "Jines",
                Losses = 2,
                Wins = 21
            };
            Player p3 = new Player()
            {
                Fname = "jemmy",
                Lname = "Janes",
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
