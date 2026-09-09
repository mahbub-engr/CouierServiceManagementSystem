using CouierServiceManagementSystemConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouierServiceManagementSystemConsoleApp.Data
{
    public interface IPackageRepository
    {
        bool AddPackage(Package package);
        Package FiendByTrackingID( string trackingId);
        bool UpdataStatus (string trackingId,string newStatus);
        DataTable GetShipments(string status,int senderId,DateTime? fromDate);

    }
}
