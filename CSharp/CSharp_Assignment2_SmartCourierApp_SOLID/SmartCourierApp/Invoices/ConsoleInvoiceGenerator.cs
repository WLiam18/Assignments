using SmartCourierApp.Models;

namespace SmartCourierApp.Invoices
{
    class ConsoleInvoiceGenerator : IInvoiceGenerator
    {
        public void ShowInvoice(CourierBooking b)
        {
            Console.WriteLine("\n-------- INVOICE --------");
            Console.WriteLine("Name        : " + b.Customer.Name);
            Console.WriteLine("From        : " + b.Parcel.FromCity);
            Console.WriteLine("To          : " + b.Parcel.ToCity);
            Console.WriteLine("Weight      : " + b.Parcel.Weight + " kg");
            Console.WriteLine("Delivery    : " + b.DeliveryType);
            Console.WriteLine("Total Charge: Rs." + b.Charge);
            Console.WriteLine("-------------------------\n");
        }
    }
}