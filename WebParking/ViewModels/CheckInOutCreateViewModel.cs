using System;
using System.ComponentModel.DataAnnotations;
using WebParking.Domain.Models;

namespace WebParking.ViewModels
{
    public class CheckInOutCreateViewModel
    {
        public long Id { get; set; }

        public CheckType CheckType { get; set; }

        [Required(ErrorMessage = "Укажите дату заезда!")]
        public DateTime? DateCheckIn { get; set; }

        [Required(ErrorMessage = "Укажите клиента!")]
        public long ClientId { get; set; }

        [Required(ErrorMessage = "Укажите транспортное средство!")]
        public long CarId { get; set; }

        [Required(ErrorMessage = "Укажите парковочное место!")]
        public long ParkingPlaceId { get; set; }

        public DateTime? DateCheckOut { get; set; }

        [Required(ErrorMessage = "Укажите тариф!")]
        public long TariffId { get; set; }

        public double TotalHours { get; set; }

        public double Sum { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }

        [Required] public DateTime Creation { get; set; }

        public string ResponsibleId { get; set; }
    }
}