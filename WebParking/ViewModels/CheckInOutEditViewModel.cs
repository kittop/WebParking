﻿using System;
using System.ComponentModel.DataAnnotations;
using WebParking.Domain.Models;

namespace WebParking.ViewModels
{
    public class CheckInOutEditViewModel
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public CheckType CheckType { get; set; }

        [Required(ErrorMessage = "Укажите дату заезда!")]
        public DateTime DateCheckIn { get; set; }

        [Required]
        public long ClientId { get; set; }

        [Required]
        public long CarId { get; set; }

        [Required]
        public long ParkingPlaceId { get; set; }

        [Required]
        public DateTime DateCheckOut { get; set; }

        [Required]
        public long TariffId { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }

        [Required] public DateTime Creation { get; set; }

        public string ResponsibleId { get; set; }
    }
}