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
        [MinLength(2), MaxLength(30)]
        public string Mark { get; set; }

        [Required]
        public CarCategory Category { get; set; }

        [Required]
        [MinLength(2), MaxLength(30)]
        public string StatetNumber { get; set; }

        [Required]
        [MinLength(2), MaxLength(30)]
        public string Color { get; set; }

        [Required]
        [MaxLength(300)]
        public string Condition { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }

        [Required]
        public DateTime Creation { get; set; }

    }
}
