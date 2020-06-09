using System;
using System.ComponentModel.DataAnnotations;

namespace WebParking.Domain.Models
{
    public class ParkingPlace
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        public bool Free { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }

        [Required] public WebParkingUser Responsible { get; set; }

        [Required] public string ResponsibleId { get; set; }

        [Required]
        public DateTime Creation { get; set; }
    }
}
