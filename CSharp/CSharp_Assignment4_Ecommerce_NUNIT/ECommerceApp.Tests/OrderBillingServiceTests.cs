using NUnit.Framework;
using ECommerceApp.Services;

namespace ECommerceApp.Tests;

[TestFixture]
public class OrderBillingServiceTests
{
    private OrderBillingService _service;

    [SetUp]
    public void Setup()
    {
        _service = new OrderBillingService();
    }

    // SubTotal tests
    [Test]
    public void SubTotal_Price100_Qty3_Returns300()
    {
        decimal result = _service.CalculateSubTotal(100, 3);
        Assert.That(result, Is.EqualTo(300));
    }

    [Test]
    public void SubTotal_PriceZero_ThrowsError()
    {
        var ex = Assert.Throws<ArgumentException>(() => 
            _service.CalculateSubTotal(0, 5));
        
        Assert.That(ex.Message, Is.EqualTo("Product price must be greater than 0"));
    }

    [Test]
    public void SubTotal_QtyZero_ThrowsError()
    {
        var ex = Assert.Throws<ArgumentException>(() => 
            _service.CalculateSubTotal(100, 0));
        
        Assert.That(ex.Message, Is.EqualTo("Quantity must be greater than 0"));
    }

    // Discount tests
    [Test]
    public void Discount_Amount8000_Returns800()
    {
        decimal result = _service.CalculateDiscount(8000);
        Assert.That(result, Is.EqualTo(800));
    }

    [Test]
    public void Discount_Amount3000_Returns150()
    {
        decimal result = _service.CalculateDiscount(3000);
        Assert.That(result, Is.EqualTo(150));
    }

    [Test]
    public void Discount_Amount1000_Returns0()
    {
        decimal result = _service.CalculateDiscount(1000);
        Assert.That(result, Is.EqualTo(0));
    }

    // Delivery charge tests
    [Test]
    public void Delivery_Amount500_Returns100()
    {
        decimal result = _service.CalculateDeliveryCharge(500);
        Assert.That(result, Is.EqualTo(100));
    }

    [Test]
    public void Delivery_Amount1500_Returns0()
    {
        decimal result = _service.CalculateDeliveryCharge(1500);
        Assert.That(result, Is.EqualTo(0));
    }

    // Final amount tests
    [Test]
    public void Final_Price100_Qty3_Returns400()
    {
        decimal result = _service.CalculateFinalAmount(100, 3);
        Assert.That(result, Is.EqualTo(400));
    }

    [Test]
    public void Final_Price500_Qty10_Returns4500()
    {
        decimal result = _service.CalculateFinalAmount(500, 10);
        Assert.That(result, Is.EqualTo(4500));
    }

    [Test]
    public void Final_Price300_Qty10_Returns2850()
    {
        decimal result = _service.CalculateFinalAmount(300, 10);
        Assert.That(result, Is.EqualTo(2850));
    }
}