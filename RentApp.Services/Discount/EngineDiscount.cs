using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Services.Discount
{
    public class EngineDiscount
    {
        public static decimal ApplyEngineDiscount(decimal price, string engineType)
        {
            if (engineType == "Electric")
                return price * 0.85m; // 15% discount for electric vehicles

            return price; // No discount for other engine types
        }

    }
}
