using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Services.Discount
{
    public abstract class DiscountableCustomer
    {
        public abstract decimal GetDiscount(decimal price);
    }

    public class NormalCustomer : DiscountableCustomer
    {
        public override decimal GetDiscount(decimal price) => price * 0.05m; // 5% discount
    }

    public class PremiumCustomer : DiscountableCustomer
    {
        public override decimal GetDiscount(decimal price) => price * 0.1m; // 10% discount
    }

}
