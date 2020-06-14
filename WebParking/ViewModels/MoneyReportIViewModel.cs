using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebParking.Domain.Models;

namespace WebParking.ViewModels
{
    public class MoneyReportViewModel
    {
        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime Finish { get; set; }

        public List<MoneyReportItemViewModel> Item { get; set; }
    }
}