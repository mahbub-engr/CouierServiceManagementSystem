using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouierServiceManagementSystemConsoleApp.Models
{
    internal class Delivery
    {
        public string TrackingID { get; set; }
        public int  CourierID { get; set; }
        public string PickupLocation { get; set; }
        public string DropLocation { get; set; }
        public DateTime AssignmentDateTime { get; set; }
        public DateTime DeliveryDateTime { get; set; }
        private string ConnectionString = "server=.;database =DB_Courier_SMS; integrated security = true";


        public bool AssignCourier ()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = @"INSERT INTO tbl_delivery (TrackingID, CourierID, PickupLocation, DropLocation, AssignmentDateTime)
                              VALUES (@TrackingID, @CourierID, @PickupLocation, @DropLocation,@AssignmentDateTime)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@TrackingID", TrackingID);
                    cmd.Parameters.AddWithValue("@CourierID", CourierID);
                    cmd.Parameters.AddWithValue("@PickupLocation", PickupLocation);
                    cmd.Parameters.AddWithValue("@DropLocation", DropLocation);
                    cmd.Parameters.AddWithValue("@AssignmentDateTime", AssignmentDateTime);
                    connection.Open();
                    int res =cmd.ExecuteNonQuery();
                    if (res>0)
                    {
                        UpdateCourierStatus(CourierID,"Busy");
                        return true;
                    }
                    return false;
                    
                }


            }
        }
        public void UpdateCourierStatus(int courierId, string status)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString)) {
                string updatequery = @"update tbl_courier set Status = @Status where CourierID = @CourierID ";
                using (SqlCommand cmd = new SqlCommand(updatequery,connection))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@CourierID", courierId);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                

            }

        }
    }
}
