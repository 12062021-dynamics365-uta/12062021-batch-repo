using System;
using System.Data.SqlClient;
namespace CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
         String str = "Data source =.;initial Catalog=DXC; integrated security =true";
            SqlConnection con = new SqlConnection(str);
            string querystring = "select * from employee1";
            con.Open();
            SqlCommand cmd = new SqlCommand(querystring, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Console.WriteLine(dr[0].ToString() + "  " + dr[1].ToString() + "   " + dr[2].ToString() + "   " + dr[3].ToString());
            }


        }
    }
}
