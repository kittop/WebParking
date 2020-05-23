using System;
using System.ComponentModel.DataAnnotations;

namespace WebParking.ViewModels
{
    public class TariffEditViewModel
    {
        [Required] public long Id { get; set; }

        [Required(ErrorMessage = "Наименование не указано!")]
        [MinLength(2, ErrorMessage = "Минимальное количество символов не менее 2!"), MaxLength(15, ErrorMessage = "Максимальное количество символов не более 15!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Цена не указана!")]
        public double Price { get; set; }

        [MinLength(4, ErrorMessage = "Минимальное количество символов не менее 4!"), MaxLength(300, ErrorMessage = "Максимальное количество символов не должно превышать 300!")]
        public string Notes { get; set; }

        [Required] public DateTime Creation { get; set; }

        //ответственный
        [Required] public int Responsible { get; set; }
    }
}