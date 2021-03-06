using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlayLogic1
{
    public class Mapper : IMapper
    {
        public Player EntityToPlayer(SqlDataReader dr)
        {
            //call the dr.Read() method to get the entity returned
            if (dr.Read())
            {
                Player p = new Player()
                {
                    PlayerId = Convert.ToInt32(dr[0]),
                    Fname = Convert.ToString(dr[1]),
                    Lname = Convert.ToString(dr[2]),
                    Losses = Convert.ToInt32(dr[3]),
                    Wins = Convert.ToInt32(dr[4])
                };
                dr.Close();
                return p;
            }
            else return null;
        }

        /// <summary>
        /// This method will convert an entity returned from the Db to a Player object
        /// </summary>
        public List<Player> EntityToPlayerList(SqlDataReader dr)
        {
            List<Player> players = new List<Player>();
            while (dr.Read())
            {
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

    }
}
