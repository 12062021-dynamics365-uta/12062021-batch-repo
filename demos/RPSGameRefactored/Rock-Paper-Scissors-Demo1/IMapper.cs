using System.Collections.Generic;
using System.Data.SqlClient;

namespace Rock_Paper_Scissors_Demo1
{
    internal interface IMapper
    {
        List<Player> EntityToPlayerList(SqlDataReader dr);
    }
}