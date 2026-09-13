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
        CustomerRepository customerRepository = new CustomerRepository();
        public Guid Add (Customer customer)
        {

            if (customer !=null)
            {
                customer.CustomerID = Guid.NewGuid();
                if (customer.Name !="" && customer.Phone !="" && customer.Address !="")
                {
                   return customerRepository.AddCustomer(customer);
                }
                else
                {
                    Console.WriteLine("Invalid customer information");

                }
            }else
            {
                Console.WriteLine("Invalid input");
            }
            return Guid.Empty;
        }
        public bool CheckCustomerExistOrNot ( Customer customer)
        {

            bool IsChecked  =  customerRepository.CheckCustomerExistOrNot (customer);
            return IsChecked;
        }

        public Customer FindByPhone(string phone)
        {
            return customerRepository.FindByPhone(phone);
        }


        public Customer FindByID(string id)
        {
            return customerRepository.FindByID(id);
        }
    }
}
