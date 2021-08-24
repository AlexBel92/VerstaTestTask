using System;
using System.ComponentModel.DataAnnotations;

namespace VerstaTestTask.Models
{    
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            SenderAddress = new AddressViewModel();
            RecipientAddress = new AddressViewModel();
        }

        public int OrderId { get; set; }

        [Display(Name = "Дата забора груза"), DataType(DataType.Date)]
        [Required(ErrorMessage = "Дата забора груза обязательное поле")]        
        //[DateTimeRange]
        public DateTime PickUpDate { get; set; }

        [Display(Name = "Вес груза")]
        [Required(ErrorMessage = "Вес груза груза обязательное поле")]
        [Range(1, 1000, ErrorMessage = "Вес может быть от 1 до 1000")]
        public int CargoWeight { get; set; }
        
        public AddressViewModel SenderAddress { get; set; }

        public AddressViewModel RecipientAddress { get; set; }
    }
}
