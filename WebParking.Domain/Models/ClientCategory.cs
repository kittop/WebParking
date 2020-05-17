using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebParking.Domain.Models
{
    public class ClientCategory
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
        [Required] public int Responsible { get; set; }

    }
}
