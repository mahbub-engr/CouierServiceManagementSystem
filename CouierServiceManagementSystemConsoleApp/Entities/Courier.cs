using CouierServiceManagementSystemConsoleApp.Data;
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
    public class Courier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ECourierStatus Status { get; set; }
        public string Phone {  get; set; }
    }
}
