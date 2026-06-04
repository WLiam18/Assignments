namespace SmartCourierApp.DeliveryCalculators
{
    class ExpressDeliveryCalculator : IDeliveryChargeCalculator
    {
        public double Calculate(double weight)
        {
            return (weight * 80) + 100;
        }
    }
}