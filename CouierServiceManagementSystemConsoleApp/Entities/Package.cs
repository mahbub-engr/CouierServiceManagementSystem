using CouierServiceManagementSystemConsoleApp.Data;
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
    public class Package
    {
        public Guid TrackingID { get; set; }
        public string SenderID { get; set; }
        public string ReceiverID { get; set; }
        public double Weight {  get; set; }
        public EStatus Status  { get; set; }


        public Customer Sender { get; set; }
        public Customer Receiver { get; set; }

    }
}
 