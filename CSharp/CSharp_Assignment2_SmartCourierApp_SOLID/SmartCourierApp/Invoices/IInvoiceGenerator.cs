using SmartCourierApp.Models;

namespace SmartCourierApp.Invoices
{
    interface IInvoiceGenerator
    {
        void ShowInvoice(CourierBooking b);
    }
}