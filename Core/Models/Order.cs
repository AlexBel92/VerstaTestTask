using System;
using System.ComponentModel.DataAnnotations;

namespace VerstaTestTask.Core.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime PickUpDate { get; set; }

        public int CargoWeight { get; set; }

        [Required]
        public City RecipientCity { get; set; }
        [Required]
        public Address RecipientAddress { get; set; }

        [Required]
        public City SenderCity { get; set; }
        [Required]
        public Address SenderAddress { get; set; }
    }
}
