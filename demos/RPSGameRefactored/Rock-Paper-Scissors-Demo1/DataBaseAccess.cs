using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors_Demo1
{
    internal class DataBaseAccess : IDataBaseAccess
    {
        private readonly string str = "Data source =MARKCMOORE\\SQLEXPRESS;initial Catalog=RpsGameDb; integrated security =true";
        private readonly SqlConnection _con;
        private readonly IMapper _mapper;

        //constructor
        public DataBaseAccess()
        {
            this._con = new SqlConnection(this.str);
            _con.Open();
            this._mapper = new Mapper();
        }

        internal List<Player> GetAllPlayers()
        {
            string sqlQuery = "SELECT * FROM Players;";
            List<Player> players = new List<Player>();  
            using (SqlCommand cmd = new SqlCommand(sqlQuery,this._con))
            {
                SqlDataReader dr = cmd.ExecuteReader();
                players = this._mapper.EntityToPlayerList(dr);
                this._con.Close();// make sure this class is Transient... not songleton or Scoped.
            }
            return players;
        }



    }//EoC
}//EoN
