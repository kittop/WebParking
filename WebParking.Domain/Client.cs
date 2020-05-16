using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebParking.Domain
{
    public class Client
    {
        public long Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        public string MiddleName { get; set; }

        [Required]
        [MinLength(2), MaxLength(30)]
        public string Telephone { get; set; }

        //[Required]
        //public int Category { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public DocumentType DocumentType { get; set; }

        [MinLength(2), MaxLength(15)]
        public string Document { get; set; }

        [MaxLength(50)]
        public string Notes { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        public DateTime Creation { get; set; }
    }
    public enum DocumentType { Other, Passport };
}
