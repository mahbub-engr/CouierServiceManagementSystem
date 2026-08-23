using CouierServiceManagementSystemConsoleApp.Models;


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
delivery.AssignCourier();





