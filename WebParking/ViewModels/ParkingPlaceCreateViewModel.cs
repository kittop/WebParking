using System;
using System.ComponentModel.DataAnnotations;

namespace WebParking.ViewModels
{
    public class ParkingPlaceCreateViewModel
    {
        [Required(ErrorMessage = "Наименование не указано!")]
        [MinLength(2, ErrorMessage = "Минимальное количество символов не менее 2!"), MaxLength(15, ErrorMessage = "Максимальное количество символов не более 15!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Наличие свободного места не заполнено!")]
        //[MinLength(2, ErrorMessage = "Минимальное количество символов не менее 2!"), MaxLength(30, ErrorMessage = "Максимальное количество символов не должно превышать 30!")]
        public bool Free { get; set; }

        [Required] public long CategoryId { get; set; }
        //public AutoCategoriesCreateViewModel Category { get; set; }   

        [MinLength(4, ErrorMessage = "Минимальное количество символов не менее 4!"), MaxLength(300, ErrorMessage = "Максимальное количество символов не должно превышать 300!")]
        public string Notes { get; set; }

        [Required] public DateTime Creation { get; set; }
    }
}