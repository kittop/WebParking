using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebParking.Domain
{
    public class Client
    {
        public long Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Telephone { get; set; }

        //[Required]
        //public int Category { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Passport { get; set; }

        [Required]
        public string Notes { get; set; }

        [Required]
        public DateTime Creation { get; set; }
    }
}
