using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace CustomerTask.Models
{
    // Models used as parameters to AccountController actions.
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        public string Surname { get; set; }

        [RegularExpression(@"^([0-9]{9})|(([0-9]{3}-){2}[0-9]{3})$",ErrorMessage = "Wrong phone number")]
        [Required]
        public string Phone { get; set; }
        [Required]

        public AddressDto Address { get; set; }
    }
}
