using System.ComponentModel.DataAnnotations;

namespace CustomerTask.Models
{
    public class AddressDto
    {
        public int Id { get; set; }
        [Required]

        public string City { get; set; }

        [RegularExpression(@"^[0-9]{2}-[0-9]{3}$", ErrorMessage = "Wrong phone number")]
        [Required]
        public string PostalCode { get; set; }
        [Required]

        public string Street { get; set; }
    }
}