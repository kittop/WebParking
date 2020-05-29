using System;
using System.ComponentModel.DataAnnotations;

namespace WebParking.ViewModels
{
    public class CarEditViewModel
    {
        [Required] public long Id { get; set; }

        [Required(ErrorMessage = "Марка не указана!")]
        [MinLength(2, ErrorMessage = "Минимальное количество символов не менее 2!"), MaxLength(30, ErrorMessage = "Максимальное количество символов не более 15!")]
        public string Mark { get; set; }

        [Required(ErrorMessage = "Госномер не указан!")]
        [MinLength(2, ErrorMessage = "Минимальное количество символов не менее 2!"), MaxLength(30, ErrorMessage = "Максимальное количество символов не более 20!")]
        public string SatetNumber { get; set; }

        [Required(ErrorMessage = "Цвет не указан!")]
        [MinLength(2, ErrorMessage = "Минимальное количество символов не менее 2!"), MaxLength(30, ErrorMessage = "Максимальное количество символов не более 20!")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Состояние не указано!")]
        [MaxLength(300, ErrorMessage = "Максимальное количество символов не должно превышать 300!")]
        public string Condition { get; set; }

        [MaxLength(300, ErrorMessage = "Максимальное количество символов не должно превышать 300!")]
        public string Notes { get; set; }

        [Required] public DateTime Creation { get; set; }
    }
}