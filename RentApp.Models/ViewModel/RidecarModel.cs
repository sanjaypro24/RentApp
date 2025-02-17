using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Models.ViewModel
{
    public class RidecarModel
    {
        [Key]
        public Guid Carid { get; set; }
        public string CarName { get; set; }
        public int CarPrice { get; set; }

        public string CarEngine { get; set; }
    }
}
