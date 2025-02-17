﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Repository.Entities
{
    public class Book
    {
        [Key]
        public Guid Bookid { get; set; }
        public int Uid { get; set; }
        public int Cid { get; set; }
        public String Customertype { get; set; }
       
        public string Location { get; set; }

        public String Engine { get; set; }

        public int Duration { get; set; }
    }
}
