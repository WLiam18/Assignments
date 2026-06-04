namespace SmartCourierApp.DeliveryCalculators
{
    interface IDeliveryChargeCalculator
    {
        double Calculate(double weight);
    }
}