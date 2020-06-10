using System;
using System.ComponentModel.DataAnnotations;

namespace WebParking.Domain.Models
{
    public class Tariff
    {
        public long Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(15)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public AccrualType AccrualType { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        //ответственный
        [Required] public WebParkingUser Responsible { get; set; }

        [Required] public string ResponsibleId { get; set; }

    }
    public enum AccrualType { Hourly, Daily };  //вид начисления

}
