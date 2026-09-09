using CouierServiceManagementSystemConsoleApp.Data;
using CouierServiceManagementSystemConsoleApp.Models;
using CouierServiceManagementSystemConsoleApp.Services;


Courier courier = new Courier();
courier.Name = "Salauddin";
courier.Status = "Available";
//courier.AddCourier();
Package package = new Package();
package.SenderID = "13EDF64A-06A8-4E5F-88A5-054B16E72707";
package.ReceiverID = "E8C2E676-1C83-4C30-9A11-CA6650FAABDC";
package.Status = "Pending";
package.Weight = 1;
//package.AddPackage();

Delivery delivery = new Delivery();
delivery.TrackingID = "34252EF6-F22E-4024-BFDA-76A979B983A5";
delivery.CourierID = 1000;
delivery.PickupLocation = "Darsana";
delivery.DropLocation = "Kustia";
delivery.AssignmentDateTime = DateTime.Now;
//delivery.AssignCourier();


string Name = "Abdul KAlam";
string Phone = "01523654789";
string Address = "rajshahi";
ICustomerRepository customerRepository = new CustomerRepository();






CustomerService customerService = new CustomerService(customerRepository);
Customer customer =customerService.GetorCreate(Name,Phone,Address);




Console.WriteLine($"CustomerID: {customer.CustomerID}");
Console.WriteLine($"Name: {customer.Name}");
Console.WriteLine($"Phone: {customer.Phone}");
Console.WriteLine($"Address: {customer.Address}");



