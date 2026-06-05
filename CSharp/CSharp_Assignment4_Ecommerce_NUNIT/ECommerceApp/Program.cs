using ECommerceApp.Services;

namespace ECommerceApp;

class Program
{
    static void Main(string[] args)
    {
        OrderBillingService service = new OrderBillingService();
        
        Console.Write("Enter product price: ₹");
        decimal price = decimal.Parse(Console.ReadLine());
        
        Console.Write("Enter quantity: ");
        int qty = int.Parse(Console.ReadLine());
        
        try
        {
            decimal final = service.CalculateFinalAmount(price, qty);
            Console.WriteLine($"Final Amount: ₹{final}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}