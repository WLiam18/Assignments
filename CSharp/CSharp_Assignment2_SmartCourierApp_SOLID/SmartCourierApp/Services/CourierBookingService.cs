using SmartCourierApp.DeliveryCalculators;
using SmartCourierApp.Invoices;
using SmartCourierApp.Models;
using SmartCourierApp.Notifications;

namespace SmartCourierApp.Services
{
    class CourierBookingService
    {
        IDeliveryChargeCalculator calc;
        INotificationService notify;
        IInvoiceGenerator invoice;

        public CourierBookingService(IDeliveryChargeCalculator c, INotificationService n, IInvoiceGenerator i)
        {
            calc = c;
            notify = n;
            invoice = i;
        }

        public void Book(CourierBooking b)
        {
            b.Charge = calc.Calculate(b.Parcel.Weight);
            notify.Send("Courier booked successfully!");
            invoice.ShowInvoice(b);
        }
    }
}