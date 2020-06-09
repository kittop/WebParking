using System;
using System.ComponentModel.DataAnnotations;

namespace WebParking.ViewModels
{
    public class ParkingPlaceEditViewModel
    {
        [Required] public long Id { get; set; }

        [Required(ErrorMessage = "Наименование не указано!")]
        [MaxLength(20, ErrorMessage = "Максимальное количество символов не более 20!")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Индикатор свободного места не указан!")]
        public bool Free { get; set; }

        [MaxLength(300, ErrorMessage = "Максимальное количество символов не должно превышать 300!")]
        public string Notes { get; set; }

        [Required] public DateTime Creation { get; set; }

        public string ResponsibleId { get; set; }

    }
}