using CouierServiceManagementSystemConsoleApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouierServiceManagementSystemConsoleApp.Data
{
    public class PackageRepository:IPackageRepository
    {
        public Guid AddPackage( Package package )
        {
            package.TrackingID = Guid.NewGuid();
            using (SqlConnection connection = new SqlConnection(DBConnection.ConnectionString))
            {
                string insertQuery = @"Insert into tbl_package (SenderID,ReceiverID,Weight,Status) 
                                        values (@SenderID,@ReceiverID,@Weight,@Status);
                                        SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@SenderID", package.SenderID);
                    cmd.Parameters.AddWithValue("@ReceiverID", package.ReceiverID);
                    cmd.Parameters.AddWithValue("@Weight", package.Weight);
                    cmd.Parameters.AddWithValue("@Status", package.Status.ToString());
                    connection.Open();
                    int res = cmd.ExecuteNonQuery();
                    

                }
               


            }
            return package.TrackingID;
        }



        public Package FiendByTrackingID(string trackingId)
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.ConnectionString)) {
                string selectQuery = @"
                select p.TrackingID,
                       p.Weight,
                       p.Status,
                    s.CustomerID as Sender_ID,
                    s.Name as Sender_Name,
                    s.Phone as Sender_Phone,
                    s.Address as Sender_Address,
                    r.CustomerID as Receiver_ID,
                    r.Name as Receiver_Name,
                    r.Phone as Receiver_Phone,
                    r.Address as Receiver_Address 
                    from tbl_package p
                    inner join tbl_customer s on p.SenderID = s.CustomerID
                    inner join tbl_customer  r on p.ReceiverID = r.CustomerID
                    where p.TrackingID = @TrackingID";
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@TrackingID",trackingId);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Package
                            {
                                TrackingID =Guid.Parse(reader["TrackingID"].ToString()),
                                SenderID = reader["Sender_ID"].ToString(),
                                ReceiverID = reader["Receiver_ID"].ToString(),
                                Weight = Convert.ToDouble(reader["Weight"]),
                                Status = (EStatus)Enum.Parse(typeof(EStatus), reader["Status"].ToString()),

                                Sender = new Customer
                                {
                                    CustomerID = Guid.Parse(reader["Sender_ID"].ToString()),
                                    Name = reader["Sender_Name"].ToString(),
                                    Phone = reader["Sender_Phone"].ToString(),
                                    Address = reader["Sender_Address"].ToString()
                                },
                                Receiver = new Customer
                                {
                                    CustomerID = Guid.Parse(reader["Receiver_ID"].ToString()),
                                    Name = reader["Receiver_Name"].ToString(), // Matches alias from SQL query
                                    Phone = reader["Receiver_Phone"].ToString(),
                                    Address = reader["Receiver_Address"].ToString()
                                }
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool UpdataStatus(string trackingId, EStatus newStatus)
        {
            string updateQuery = @"update tbl_package set Status = @newStatus
                                    where TrackingID = @trackingId";
            using (SqlConnection connection = new SqlConnection(DBConnection.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(updateQuery,connection))
            {
                cmd.Parameters.AddWithValue("@newStatus", newStatus.ToString());
                cmd.Parameters.AddWithValue("@trackingId", trackingId);
                connection.Open();
                int res = cmd.ExecuteNonQuery();
                if (res >0)
                {
                    Console.WriteLine("Updated");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
                return true;
            }
        }
    }
}
