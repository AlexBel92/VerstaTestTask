using System.ComponentModel.DataAnnotations;

namespace VerstaTestTask.Core.Models
{
    public class Address
    {
        public int AddressId { get; set; }

        public int CityId { get; set; }
        [Required]
        public City City { get; set; }

        public int ZipCode { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string House { get; set; }

        public int Apartment { get; set; }
    }
}
