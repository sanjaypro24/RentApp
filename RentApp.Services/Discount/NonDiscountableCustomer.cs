using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Services.Discount
{
    
        public abstract class NonDiscountableCustomer
        {
            public string Name { get; set; }
        }

        public class EnquiryCustomer : NonDiscountableCustomer
        {
            public void EnquireCarDetails()
            {
                Console.WriteLine("Fetching car details for enquiry...");
            }
        }
    
}
