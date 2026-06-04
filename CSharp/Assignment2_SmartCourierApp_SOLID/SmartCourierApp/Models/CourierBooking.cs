namespace SmartCourierApp.Models
{
    class CourierBooking
    {
        public Customer Customer { get; set; }
        public Parcel Parcel { get; set; }
        public string DeliveryType { get; set; }
        public string NotifyType { get; set; }
        public double Charge { get; set; }
    }
}