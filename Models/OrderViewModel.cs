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

        [Display(Name = "���� ������ �����"), DataType(DataType.Date)]
        [Required(ErrorMessage = "���� ������ ����� ������������ ����")]        
        //[DateTimeRange]
        public DateTime PickUpDate { get; set; }

        [Display(Name = "��� �����")]
        [Required(ErrorMessage = "��� ����� ����� ������������ ����")]
        [Range(1, 1000, ErrorMessage = "��� ����� ���� �� 1 �� 1000")]
        public int CargoWeight { get; set; }
        
        public AddressViewModel SenderAddress { get; set; }

        public AddressViewModel RecipientAddress { get; set; }
    }
}
