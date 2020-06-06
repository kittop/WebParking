using System;
using System.ComponentModel.DataAnnotations;

namespace WebParking.Domain.Models
{
    public class CheckInOut
    {
        public long Id { get; set; }

        public CheckType CheckType { get; set; }

        [Required]
        public DateTime DateCheckIn { get; set; }

        [Required]
        public long ClientId { get; set; }

        [Required]
        public Client Client { get; set; }

        [Required]
        public long CarId { get; set; }

        [Required]
        public Car Car { get; set; }

        [Required]
        public ParkingPlace ParkingPlaceId { get; set; }

        [Required]
        public ParkingPlace ParkingPlace { get; set; }

        [Required]
        public long TariffId { get; set; }

        [Required]
        public Tariff Tariff { get; set; }


        [Required]
        public DateTime DateCheckOut { get; set; }


        public double TotalHours { get; set; }

        public double Sum { get; set; }

        //ответственный
        [Required] public WebParkingUser Responsible { get; set; }

        [Required] public string ResponsibleId { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }

    }
    public enum CheckType { Other, Passport };
}
