using System;
using System.ComponentModel.DataAnnotations;
using WebParking.Domain.Models;

namespace WebParking.ViewModels
{
    public class MoneyReportViewModel
    {
        [Required] public long ClientId { get; set; }

        [Required] public DateTime Date1 { get; set; }

        [Required] public DateTime Date2 { get; set; }

        public long Id { get; set; }

        public CheckType CheckType { get; set; }

        public DateTime DateCheckIn { get; set; }

        public Client Client { get; set; }

        public long CarId { get; set; }

        public Car Car { get; set; }

        public long ParkingPlaceId { get; set; }

        public ParkingPlace ParkingPlace { get; set; }

        public DateTime DateCheckOut { get; set; }

        public long TariffId { get; set; }

        public Tariff Tariff { get; set; }

        public double TotalHours { get; set; }

        public double Sum { get; set; }

        public string Notes { get; set; }

        public DateTime Creation { get; set; }

        public WebParkingUser Responsible { get; set; }

        public string ResponsibleId { get; set; }

    }
}