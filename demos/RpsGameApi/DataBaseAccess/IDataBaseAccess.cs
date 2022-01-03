using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess1
{
    public interface IDatabaseAccess
    {
        List<Player> GetAllPlayers();

    }
}
