using Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataBaseAccess1
{
    public class DatabaseAccess : IDatabaseAccess
    {
        // in readl life you dont want to keep your Cnn String here.... 
        // it will be pushed t our GitHub and anyone could see it.
        private readonly string str = "Data source =MARKCMOORE\\SQLEXPRESS;initial Catalog=RpsGameDb; integrated security =true";
        private readonly SqlConnection _con;

        //constructor
        public DatabaseAccess()
        {
            this._con = new SqlConnection(this.str);
            _con.Open();
        }

        public List<Player> GetAllPlayers()
        {
            string sqlQuery = "SELECT * FROM Players;";
            List<Player> players = new List<Player>();
            using (SqlCommand cmd = new SqlCommand(sqlQuery, this._con))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                //players = this._mapper.EntityToPlayerList(dr);
                this._con.Close();// make sure this class is Transient... not songleton or Scoped.
            }
            return players;
        }

        public async Task<SqlDataReader> LoginAsync(string fname, string lname)
        {
            string sqlQuery = $"SELECT TOP 1 * FROM Players WHERE Fname = @fname and Lname = @lname";

            using (SqlCommand cmd = new SqlCommand(sqlQuery, this._con))
            {
                cmd.Parameters.AddWithValue("@fname", fname);
                //cmd.Parameters["@fname"].Value = fname;// this is unneeded bc we added with the value above
                cmd.Parameters.AddWithValue("@lname", lname);
                //cmd.Parameters["@lname"].Value = lname;

                SqlDataReader dr = await cmd.ExecuteReaderAsync();

                //players = this._mapper.EntityToPlayerList(dr);
                //this._con.Close();// make sure this class is Transient... not songleton or Scoped.
                return dr;
            }
        }

        public async Task<Player> RegisterNewPlayerAsync(string fname, string lname)
        {
            // call the async method in ADO.NET to post that player
            string sqlQuery = $"INSERT INTO Players (Fname, Lname,Wins,Losses) VALUES (@fname, @lname,0,0) ";

            using (SqlCommand cmd = new SqlCommand(sqlQuery, this._con))
            {
                cmd.Parameters.AddWithValue("@fname", fname);
                //cmd.Parameters["@fname"].Value = fname;// this is unneeded bc we added with the value above
                cmd.Parameters.AddWithValue("@lname", lname);
                //cmd.Parameters["@lname"].Value = lname;

                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    return new Player() { Fname = fname, Lname = lname, Losses=5, Wins=100 };
                    //TODO return this.GetAllPlayers(fname,lname);// create the method to get one player
                }
                catch (DbException ex)// TODO do something with this exception
                {
                    return null;
                }
            }
        }
    }
}
