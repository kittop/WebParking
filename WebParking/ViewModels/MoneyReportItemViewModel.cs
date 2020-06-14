using System;
using System.ComponentModel.DataAnnotations;
using WebParking.Domain.Models;

namespace WebParking.ViewModels
{
    public class MoneyReportItemViewModel
    {
        public string ClientFullName { get; set; }

        public string ClientDocument { get; set; }

        public double Sum { get; set; }

        public double Hours { get; set; }
    }
}