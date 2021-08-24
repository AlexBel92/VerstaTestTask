using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VerstaTestTask.Core.Models
{
    public class City
    {
        public int CityId { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
