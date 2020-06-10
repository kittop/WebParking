using System;
using System.ComponentModel.DataAnnotations;

namespace WebParking.ViewModels
{
    public class ParkingPlaceFillViewModel
    {
        [Required(ErrorMessage = "Количество парковочных мест не указано!")]
        public long Count { get; set; }

        [Required(ErrorMessage = "Начальное наименование не указано")]
        public long Start { get; set; }
    }
}