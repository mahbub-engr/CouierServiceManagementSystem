using CouierServiceManagementSystemConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CouierServiceManagementSystemConsoleApp.Data
{
    
    public class CustomerRepository : ICustomerRepository
    {


        public Guid AddCustomer(Customer customer)
        {
            customer.CustomerID =  Guid.NewGuid();
            using (SqlConnection connection = new SqlConnection(DBConnection.ConnectionString))
            {
                string insertQuery = @"Insert into tbl_customer (CustomerID,Name,Phone,Address) 
                                        values (@CustomerID,@Name,@Phone,@Address);
                                        SELECT SCOPE_IDENTITY();";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                    cmd.Parameters.AddWithValue("@Address", customer.Address);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    

                }
            }
            return customer.CustomerID;
            
        }


        public Customer FindByID(string id)
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.ConnectionString))
            {
                string query = @"select Name,Phone,Address from tbl_customer where CustomerID = @CustomerID";
                using (SqlCommand  cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", id);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read())
                        {
                            return new Customer
                            {
                                Name = reader["Name"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Address = reader["Address"].ToString(),
                                
                            };
                        }
                    }
                }
            }
                return null;
        }

        public Customer FindByPhone(string phone)
        {
            using (SqlConnection connection = new SqlConnection(DBConnection.ConnectionString))
            {
                string query = @"select CustomerID, Name,Phone,Address from tbl_customer where Phone = @Phone";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    connection.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Customer
                            {
                                CustomerID = (Guid)reader["CustomerID"],
                                Name = reader["Name"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Address = reader["Address"].ToString(),

                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
