using System;
using System.Data;
using System.Data.SqlClient;

namespace dataTable
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter name");

                string name = Console.ReadLine();

                Console.WriteLine("Enter country");
                string country = Console.ReadLine();

                string query = "INSERT INTO Customers VALUES(@Name, @Country)";
                // string str =
              //  string query = $"INSERT INTO Customer VALUES({name}, {country})";

                string str = "Data source =.; initial Catalog = DXC; integrated security = true";
                using (SqlConnection con = new SqlConnection(str))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Country", country);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    //    {
                    //    Console.WriteLine(row["id"] + "," + row["Name"] + "," + row["email"]);
                    //}
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("oops something ", e);
            }
        }
    }
}
