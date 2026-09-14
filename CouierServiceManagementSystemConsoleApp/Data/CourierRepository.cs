using CouierServiceManagementSystemConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CouierServiceManagementSystemConsoleApp.Data
{
    internal class CourierRepository : ICourierRepository
    {
        public int Add(Courier courier)
        {
            int id ;
            string insertQuery = @"Insert into tbl_courier (Name,Status,Phone) values (@Name,@Status,@Phone);select scope_identity(); ";
            using (SqlConnection connection = new SqlConnection(DBConnection.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", courier.Name);
                    cmd.Parameters.AddWithValue("@Status", courier.Status.ToString());
                    cmd.Parameters.AddWithValue("@Phone", courier.Phone);
                    connection.Open();
                    
                    return Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
            }
        }

        public Courier FindById(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStatus(int courierId, string status)
        {
            throw new NotImplementedException();
        }
    }
}
