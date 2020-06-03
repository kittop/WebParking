using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebParking.Domain.Models
{
    public class Client
    {
        public long Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(15)]
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

        public long CategoryId { get; set; }

        // Clients -[1]----[1]-> ClientCategories
        public ClientCategory Category { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public DocumentType DocumentType { get; set; }

        [MinLength(4), MaxLength(18)]
        public string Document { get; set; }

        [MaxLength(300)]
        public string Notes { get; set; }

        [Required]
        public DateTime Creation { get; set; }

        [Required]
        public IList<Car> Cars { get; set; }
    }
    public enum DocumentType { Other, Passport };
}
