using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication10.Models
{
    public class User
    {
        [EmailAddress(ErrorMessage ="Provide a Valid Email"),Required(ErrorMessage ="Enter Username")]
        public string? Username { get; set; }
        [Required(ErrorMessage ="Enter Password")]
        public int? Password { get; set; }
        [Required(ErrorMessage = "Enter Your Name"),StringLength(30,ErrorMessage ="Name cannot exceeds thirty characters")]
        public string? Name { get; set; }
        [Range(15,100,ErrorMessage ="Age must be in between 15 and 100"),Required]
        public int? Age { get; set; }
    }
}
