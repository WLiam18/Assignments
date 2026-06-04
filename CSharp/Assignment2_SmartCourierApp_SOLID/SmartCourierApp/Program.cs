using SmartCourierApp.DeliveryCalculators;
using SmartCourierApp.Invoices;
using SmartCourierApp.Models;
using SmartCourierApp.Notifications;
using SmartCourierApp.Services;

class Program
{
    static void Main()
    {
        Console.WriteLine("--- SmartCourier App ---\n");

        Console.Write("Customer Name   : ");
        string name = Console.ReadLine();

        Console.Write("Customer Email  : ");
        string email = Console.ReadLine();

        Console.Write("Mobile Number   : ");
        string mobile = Console.ReadLine();

        Console.Write("Parcel Weight   : ");
        double weight = double.Parse(Console.ReadLine());

        Console.Write("Source City     : ");
        string from = Console.ReadLine();

        Console.Write("Destination City: ");
        string to = Console.ReadLine();

        Console.WriteLine("Delivery Type: 1-Standard  2-Express  3-International");
        Console.Write("Enter choice: ");
        string deliveryChoice = Console.ReadLine();

        Console.WriteLine("Notification : 1-Email  2-SMS  3-WhatsApp");
        Console.Write("Enter choice: ");
        string notifChoice = Console.ReadLine();

        Customer customer = new Customer();
        customer.Name = name;
        customer.Email = email;
        customer.Mobile = mobile;

        Parcel parcel = new Parcel();
        parcel.Weight = weight;
        parcel.FromCity = from;
        parcel.ToCity = to;

        string deliveryType = "";
        if (deliveryChoice == "1") deliveryType = "Standard";
        else if (deliveryChoice == "2") deliveryType = "Express";
        else deliveryType = "International";

        string notifyType = "";
        if (notifChoice == "1") notifyType = "Email";
        else if (notifChoice == "2") notifyType = "SMS";
        else notifyType = "WhatsApp";

        CourierBooking booking = new CourierBooking();
        booking.Customer = customer;
        booking.Parcel = parcel;
        booking.DeliveryType = deliveryType;
        booking.NotifyType = notifyType;

        IDeliveryChargeCalculator calc;
        if (deliveryChoice == "1") calc = new StandardDeliveryCalculator();
        else if (deliveryChoice == "2") calc = new ExpressDeliveryCalculator();
        else calc = new InternationalDeliveryCalculator();

        INotificationService notify;
        if (notifChoice == "1") notify = new EmailNotificationService();
        else if (notifChoice == "2") notify = new SmsNotificationService();
        else notify = new WhatsAppNotificationService();

        CourierBookingService service = new CourierBookingService(calc, notify, new ConsoleInvoiceGenerator());
        service.Book(booking);
    }
}