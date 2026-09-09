using CouierServiceManagementSystemConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouierServiceManagementSystemConsoleApp.Data
{
    public interface ICustomerRepository
    {
        Guid AddCustomer(Customer customer);
        Customer FindByPhone (string phone);
        Customer FindByID (string id);
    }
}
