using System;
using System.ComponentModel.DataAnnotations;

namespace WebParking.Domain.Models
{
    public class Car
    {
        public long Id { get; set; }

        [Required]
        public Client Client { get; set; }

        [Required]
        public long ClientId { get; set; }

        [Required]
        [MinLength(2), MaxLength(30)]
        public string Mark { get; set; }

        [Required]
        public CarCategory Category { get; set; }

        [Required]
        public long CategoryId { get; set; }

        [Required]
        [MinLength(2), MaxLength(30)]
        public string StateNumber { get; set; }

        [Required]
        [MinLength(2), MaxLength(30)]
        public string Color { get; set; }

        [Required]
        [MaxLength(300)]
        public string Condition { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }

        //ответственный
        [Required] public WebParkingUser Responsible { get; set; }

        [Required] public string ResponsibleId { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        public string FullName => $"{Mark} {StateNumber} {Color}";

    }
}
