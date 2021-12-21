using System;
using System.Data.SqlClient;

namespace Insert_operation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string str = "Data source =.; initial Catalog = DXC; integrated security = true";
                using (SqlConnection con = new SqlConnection(str))
                {
                    SqlCommand cmd = new SqlCommand("Insert into employee1 values('Mark','Mark@revature.com','trainer','revature')", con);
                    con.Open();
                    int row = cmd.ExecuteNonQuery();
                    Console.WriteLine("insert rows" + row);
                    cmd.CommandText="update employee1 set CompanyName ='Niit' where companyName ='NIIT'";
                    row = cmd.ExecuteNonQuery();
                    Console.WriteLine("updated rows" + row);
                    cmd.CommandText = "Delete from employee1 where EmployeeName='Deepti Shukla'";
                    row = cmd.ExecuteNonQuery();
                    Console.WriteLine("rows deleted" + row);

                }
            }catch (Exception e)
            {
                Console.WriteLine("OOPS something went wrong" +e);
            }
        }
    }
}
