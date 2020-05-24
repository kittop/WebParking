using System;
using System.ComponentModel.DataAnnotations;

namespace WebParking.Domain.Models
{
    public class ParkingPlace
    {
        public long Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(15)]
        public string Name { get; set; }

        public long CategoryId { get; set; }

        public AutoCategory Category { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        public bool Free { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        public DateTime Creation { get; set; }
    }
}
