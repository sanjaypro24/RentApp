using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApp.Services.Discount;

namespace RentApp.Services.Price
{
    public class PriceCalculator
    {
        private const decimal BasePricePerHour = 45;

        public decimal CalculatePrice(int duration, string customerType, string location, string engineType)
        {
            decimal totalPrice = BasePricePerHour * duration;

            //Location-based discount
            if (location == "Chennai")
                totalPrice *= 0.9m; // 10% discount

            //Engine-based discount
            totalPrice = EngineDiscount.ApplyEngineDiscount(totalPrice, engineType);

            // Customer-based discount
            DiscountableCustomer discountableCustomer = null;

            if (customerType == "Normal")
                discountableCustomer = new NormalCustomer();
            else if (customerType == "Premium")
                discountableCustomer = new PremiumCustomer();

            if (discountableCustomer != null)
                totalPrice -= discountableCustomer.GetDiscount(totalPrice);

            return totalPrice;
        }
    }
}
