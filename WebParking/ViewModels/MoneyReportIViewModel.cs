using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebParking.Domain.Models;

namespace WebParking.ViewModels
{
    public class MoneyReportViewModel
    {
        [Required(ErrorMessage = "Укажите начальную дату!")]
        public DateTime? Start { get; set; }

        [Required(ErrorMessage = "Укажите конечную дату!")]
        public DateTime? Finish { get; set; }

        public IEnumerable<MoneyReportItemViewModel> Item { get; set; }
    }
}