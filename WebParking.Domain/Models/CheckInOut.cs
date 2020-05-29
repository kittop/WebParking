using System;
using System.ComponentModel.DataAnnotations;

namespace WebParking.Domain.Models
{
    public class CheckInOut
    {
        public long Id { get; set; }

        [Required]
        public DateTime DateCreation { get; set; }//дата создания = дата заезда при создании записи в БД

        [Required]
        public CheckType CheckType { get; set; }

        public long ParkingPlaceId { get; set; }

        [Required]
        public ParkingPlace ParkingPlace { get; set; }

        [Required]
        public long ClientId { get; set; }

        [Required]
        public Client Client { get; set; }

        [Required]
        public string Mark { get; set; }

        [Required]
        public string StateNumber { get; set; }

        [Required]
        public long TariffId { get; set; }

        [Required]
        public Tariff Tariff { get; set; }

        [Required]
        public DateTime DateCheckOut { get; set; }

        [Required]
        public string TotalHours { get; set; }

        [Required]
        [MinLength(4), MaxLength(18)]
        public double Sum { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }

        //ответственный
        [Required] string Responsible { get; set; }

        //ответственный
        [Required] string ResponsibleId { get; set; }
    }

    public enum CheckType { CheckIn, CheckOut };

}
