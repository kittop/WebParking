﻿using System;
using System.ComponentModel.DataAnnotations;
using WebParking.Domain.Models;

namespace WebParking.ViewModels
{
    public class ClientCategoriesCreateViewModel
    {
        [Required(ErrorMessage = "Наименование не заполнено!")]
        [MinLength(2, ErrorMessage = "Минимальное количество символов не менее 2!"), MaxLength(30, ErrorMessage = "Максимальное количество символов не более 30!")]
        public string Name { get; set; }

        [MinLength(4, ErrorMessage = "Минимальное количество символов не менее 4!"), MaxLength(300, ErrorMessage = "Минимальное количество символов не должно превышать 300!")]
        public string Notes { get; set; }

        public DateTime Creation { get; set; }

        public string ResponsibleId { get; set; }
    }
}