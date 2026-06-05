using System;

namespace ECommerceApp.Services;

public class OrderBillingService
{
    public decimal CalculateSubTotal(decimal productPrice, int quantity)
    {
        if (productPrice <= 0)
            throw new ArgumentException("Product price must be greater than 0");
        
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than 0");
        
        return productPrice * quantity;
    }
    
    public decimal CalculateDiscount(decimal subTotal)
    {
        if (subTotal >= 5000)
            return subTotal * 10 / 100;
        else if (subTotal >= 2000)
            return subTotal * 5 / 100;
        else
            return 0;
    }
    
    public decimal CalculateDeliveryCharge(decimal amountAfterDiscount)
    {
        if (amountAfterDiscount < 1000)
            return 100;
        else
            return 0;
    }
    
    public decimal CalculateFinalAmount(decimal productPrice, int quantity)
    {
        decimal subTotal = CalculateSubTotal(productPrice, quantity);
        decimal discount = CalculateDiscount(subTotal);
        decimal afterDiscount = subTotal - discount;
        decimal delivery = CalculateDeliveryCharge(afterDiscount);
        
        return afterDiscount + delivery;
    }
}