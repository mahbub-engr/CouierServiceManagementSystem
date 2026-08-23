using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouierServiceManagementSystemConsoleApp.Models
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        private string ConnectionString = "server=.;database =DB_Courier_SMS; integrated security = true";
        public void AddCustomer ()
        {
            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string insertQuery = @"Insert into tbl_customer (Name,Phone,Address) values (@Name,@Phone,@Address) ";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Phone", Phone);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    connection.Open();
                   int res = cmd.ExecuteNonQuery();
                    if (res > 0) {
                        Console.WriteLine("Success");
                    }else
                    {
                        Console.WriteLine("Failed");
                    }

                }
               

            } 
        }

    }
}
