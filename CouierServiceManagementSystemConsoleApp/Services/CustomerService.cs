using CouierServiceManagementSystemConsoleApp.Data;
using CouierServiceManagementSystemConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouierServiceManagementSystemConsoleApp.Services
{
    public class CustomerService
    {
        private ICustomerRepository repository;
       public CustomerService (ICustomerRepository repository)
        {
            this.repository = repository;
            
        }
        public Customer GetorCreate (string name ,string phone,string address)
        {
            Customer existing = repository.FindByPhone(phone);
            if(existing !=null)
            {
                return existing;
            }
            Customer newCustomer = new Customer {
                CustomerID = Guid.NewGuid(),
                Name=name,
                Phone=phone,
                Address=address
            };
            repository.AddCustomer(newCustomer);
            return newCustomer;
        }

    }
}
