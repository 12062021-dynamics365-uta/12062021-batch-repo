using GamePlayLogic1;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Tests.Rps_GameApi
{
    internal class MockMapper : IMapper
    {
        public Player EntityToPlayer(SqlDataReader dr)
        {
            //call the dr.Read() method to get the entity returned
            //if (dr.Read())
            //{
            Player p = new Player()
            {
                PlayerId = 21,
                Fname = "mumbly",
                Lname = "jumbly",
                Losses = 11,
                Wins = 12
            };
            return p;
            //}
            //else return null;
        }

        /// <summary>
        /// This method will convert an entity returned from the Db to a Player object
        /// </summary>
        public List<Player> EntityToPlayerList(SqlDataReader dr)
        {
            List<Player> players = new List<Player>();
            while (dr.Read())
            {
                //Console.WriteLine(dr[0].ToString() + " " + dr[1].ToString() + "  " + dr[2].ToString() + "  " + dr[3].ToString() + "  " + dr[4].ToString());
                Player p = new Player()
                {
                    PlayerId = Convert.ToInt32(dr[0].ToString()),
                    Fname = dr[1].ToString(),
                    Lname = dr[2].ToString(),
                    Wins = Convert.ToInt32(dr[3].ToString()),
                    Losses = Convert.ToInt32(dr[4].ToString()),
                };
                players.Add(p);

            }
            return players;

        }


    }//EoC
}//EoN