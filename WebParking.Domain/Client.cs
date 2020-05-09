﻿using System;
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
    }
}
