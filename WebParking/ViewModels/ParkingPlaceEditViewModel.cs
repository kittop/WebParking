using System;
using System.ComponentModel.DataAnnotations;

namespace WebParking.ViewModels
{
    public class ParkingPlaceEditViewModel
    {
        [Required] public long Id { get; set; }

        [Required(ErrorMessage = "Наименование не указано!")]
        [MinLength(2, ErrorMessage = "Минимальное количество символов не менее 2!"), MaxLength(30, ErrorMessage = "Максимальное количество символов не более 15!")]
       
        public string Name { get; set; }
        // [Required] public long CategoryId { get; set; }

        [Required(ErrorMessage = "Наличие свободного места не указано!")]
        //[MinLength(2, ErrorMessage = "Минимальное количество символов не менее 2!"), MaxLength(30, ErrorMessage = "Максимальное количество символов не более 20!")]
        public bool Free { get; set; }

        [MaxLength(300, ErrorMessage = "Максимальное количество символов не должно превышать 300!")]
        public string Notes { get; set; }

        [Required] public DateTime Creation { get; set; }
    }
}