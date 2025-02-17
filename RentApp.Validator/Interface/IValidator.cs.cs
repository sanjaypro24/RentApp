﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Validator.Interface
{
    public interface IValidator<T>
    {
        bool Validate(T entity);
    }
}
