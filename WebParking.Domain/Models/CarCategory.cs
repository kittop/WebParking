using System;
using System.ComponentModel.DataAnnotations;

namespace WebParking.Domain.Models
{
    public class CarCategory
    {
        public long Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        //ответственный
        [Required] public WebParkingUser Responsible { get; set; }

        [Required] public string ResponsibleId { get; set; }

    }
}
