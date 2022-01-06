using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess1
{
    public interface IDatabaseAccess
    {
        List<Player> GetAllPlayers();
        Task<SqlDataReader> LoginAsync(string fname, string lname);
        Task<Player> RegisterNewPlayerAsync(string fname, string lname);
    }
}
