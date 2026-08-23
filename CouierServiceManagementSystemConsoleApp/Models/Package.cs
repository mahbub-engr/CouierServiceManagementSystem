using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CouierServiceManagementSystemConsoleApp.Models
{
    internal class Package
    {
        public string TrackingID { get; set; }
        public string SenderID { get; set; }
        public string ReceiverID { get; set; }
        public double Weight {  get; set; }
        public string Status { get; set; }
        private string ConnectionString = "server=.;database =DB_Courier_SMS; integrated security = true";


        public void AddPackage()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string insertQuery = @"Insert into tbl_package (SenderID,ReceiverID,Weight,Status) values (@SenderID,@ReceiverID,@Weight,@Status) ";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@SenderID", SenderID);
                    cmd.Parameters.AddWithValue("@ReceiverID", ReceiverID);
                    cmd.Parameters.AddWithValue("@Weight", Weight);
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
