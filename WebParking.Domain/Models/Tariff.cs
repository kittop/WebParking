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

        [MaxLength(300)]
        public string Notes { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        //ответственный
        [Required] public int Responsible { get; set; }
    }
}
