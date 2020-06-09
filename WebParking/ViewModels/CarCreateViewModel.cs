using System;
using System.ComponentModel.DataAnnotations;

namespace WebParking.ViewModels
{
    public class CarCreateViewModel
    {
        [Required(ErrorMessage = "Марка не указана!")]
        [MinLength(2, ErrorMessage = "Минимальное количество символов не менее 2!"), MaxLength(15, ErrorMessage = "Максимальное количество символов не более 15!")]
        public string Mark { get; set; }

        [Required(ErrorMessage = "Госномер не указан!")]
        [MinLength(2, ErrorMessage = "Минимальное количество символов не менее 2!"), MaxLength(30, ErrorMessage = "Максимальное количество символов не должно превышать 30!")]
        public string SatetNumber { get; set; }

        [Required] public long CategoryId { get; set; }

        [Required(ErrorMessage = "Цвет не указан!")]
        [MinLength(2, ErrorMessage = "Минимальное количество символов не менее 2!"), MaxLength(30, ErrorMessage = "Минимальное количество символов не должно превышать 30!")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Состояние автомобиля не указано!")]
        [MaxLength(300, ErrorMessage = "Максимальное количество символов не должно превышать 300!")]

        public string Condition { get; set; }

        public string ResponsibleId { get; set; }

        [MinLength(4, ErrorMessage = "Минимальное количество символов не менее 4!"), MaxLength(300, ErrorMessage = "Максимальное количество символов не должно превышать 300!")]
        public string Notes { get; set; }

        [Required] public DateTime Creation { get; set; }
    }
}