using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString)) 
            {
                string query = "Select * from tblEmployee";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd)) 
                    {
                        adapter.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow dr in dt.Rows)
                        {
                            Console.WriteLine("Id= " + dr["id"] + "Name=" + dr["Name"] + "Desination=" + dr["desg"] + "Salary=" + dr["salary"] + "Address=" + dr["address"]);
                        }
                        
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
