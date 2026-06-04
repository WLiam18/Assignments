namespace SmartCourierApp.DeliveryCalculators
{
    class StandardDeliveryCalculator : IDeliveryChargeCalculator
    {
        public double Calculate(double weight)
        {
            return weight * 50;
        }
    }
}