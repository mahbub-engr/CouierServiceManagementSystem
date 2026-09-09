using CouierServiceManagementSystemConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouierServiceManagementSystemConsoleApp.Data
{
    internal interface ICourierRepository
    {
        int Insert(Courier courier);
        DataTable GetByStatus(string status);
        Courier FindById(int id);
        bool UpdateStatus(int courierId, string status);
    }
}
