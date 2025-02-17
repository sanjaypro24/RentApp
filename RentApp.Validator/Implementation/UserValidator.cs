using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApp.Validator.Interface;

namespace RentApp.Validator.Implementation
{
    public class UserValidator : IValidator<User>  // Fix the class declaration here
    {
        public bool Validate(User user)
        {
            return user.Age >= 18;
        }
    }
}
