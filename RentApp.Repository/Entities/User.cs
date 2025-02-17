using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentApp.Repository.Entities
{
    public class User
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public int Age { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; } = null;

        public string? Password { get; set; }
        public User() { }
    }
}
