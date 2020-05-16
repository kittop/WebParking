using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;

namespace WebParking.ViewModels
{
    public class ClientEditViewModel
    {
        [Required] public long Id { get; set; }

        [Required(ErrorMessage = "Имя не указано!")]
        [MinLength(2), MaxLength(15)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилия не указана!")]
        [MinLength(2), MaxLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Отчество не указано!")]
        [MinLength(2), MaxLength(20)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Телефон не указан!")]
        [MinLength(2), MaxLength(20)]
        public string Telephone { get; set; }

        //[Required] public int Category { get; set; }

        [Required(ErrorMessage = "Дата рождения не указана!")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Документ, удостоверяющий личность, не указан!")]
        [MinLength(2), MaxLength(20)]
        public string Passport { get; set; }

        [MinLength(2), MaxLength(500)]
        [Required] public string Notes { get; set; }

        [Required] public DateTime Creation { get; set; }
    }
}