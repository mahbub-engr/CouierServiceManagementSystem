using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CouierServiceManagementSystemConsoleApp.Models
{
    internal class Courier
    {
        public string Name { get; set; }
        public string Status { get; set; }

        private string ConnectionString = "server=.;database =DB_Courier_SMS; integrated security = true";
        public void AddCourier()
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string insertQuery = @"Insert into tbl_courier (Name,Status) values (@Name,@Status) ";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    connection.Open();
                    int res = cmd.ExecuteNonQuery();
                    if (res > 0)
                    {
                        Console.WriteLine("Success");
                    }
                    else
                    {
                        Console.WriteLine("Failed");
                    }

                }


            }
        }
    }
}
