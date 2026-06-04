namespace SmartCourierApp.DeliveryCalculators
{
    class InternationalDeliveryCalculator : IDeliveryChargeCalculator
    {
        public double Calculate(double weight)
        {
            return (weight * 150) + 500;
        }
    }
}