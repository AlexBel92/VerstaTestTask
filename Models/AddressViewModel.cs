using System;
using System.ComponentModel.DataAnnotations;

namespace VerstaTestTask.Models
{
    public class AddressViewModel
    {

        [Display(Name = "Город")]
        [Required(ErrorMessage = "Название города обязательное поле")]
        public string CityName { get; set; }

        [Display(Name = "Индекс")]
        [Required(ErrorMessage = "Индекс обязательное поле")]
        [Range(100000, 999999, ErrorMessage = "Индекс должен состоять из 6 цифр")]
        public int ZipCode { get; set; }

        [Display(Name = "Улица")]
        [Required(ErrorMessage = "Улица обязательное поле")]
        public string Street { get; set; }

        [Display(Name = "Дом")]
        [Required(ErrorMessage = "Дом обязательное поле")]
        public string House { get; set; }

        [Display(Name = "Квартира")]
        [Required(ErrorMessage = "Квартира обязательное поле")]
        public int Apartment { get; set; }

        public override bool Equals(object obj)
        {
            return obj is AddressViewModel model &&
                   CityName == model.CityName &&
                   ZipCode == model.ZipCode &&
                   Street == model.Street &&
                   House == model.House &&
                   Apartment == model.Apartment;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CityName, ZipCode, Street, House, Apartment);
        }

        public override string ToString()
        {
            return CityName + ", " + ZipCode + ", " + Street + ", " + House + ", " + Apartment;
        }
    }
}
