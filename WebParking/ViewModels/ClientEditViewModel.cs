using System;
using System.ComponentModel.DataAnnotations;
using WebParking.Domain.Models;

namespace WebParking.ViewModels
{
    public class ClientEditViewModel
    {
        [Required] public long Id { get; set; }

        [Required(ErrorMessage = "Имя не указано!")]
        [MinLength(2, ErrorMessage = "Минимальное количество символов не менее 2!"), MaxLength(15, ErrorMessage = "Максимальное количество символов не более 15!")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Фамилия не указана!")]
        [MinLength(2, ErrorMessage = "Минимальное количество символов не менее 2!"), MaxLength(20, ErrorMessage = "Максимальное количество символов не более 20!")]
        public string LastName { get; set; }

        [MinLength(2, ErrorMessage = "Минимальное количество символов не менее 2!"), MaxLength(20, ErrorMessage = "Максимальное количество символов не более 20!")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Телефон не указан!")]
        [MinLength(2, ErrorMessage = "Минимальное количество символов не менее 2!"), MaxLength(30, ErrorMessage = "Максимальное количество символов не должно превышать 30!")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Категория не выбрана!")] public long CategoryId { get; set; }

        [Required(ErrorMessage = "Дата рождения не указана!")]
        [DataType(DataType.Date, ErrorMessage = "Дата рождения не указана!")]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Тип документа, удостоверяющего личность, не указан!")]
        public DocumentType DocumentType { get; set; }

        [Required(ErrorMessage = "Документ, удостоверяющий личность, не указан!")]
        [MinLength(4, ErrorMessage = "Минимальное количество символов не менее 4!"), MaxLength(18, ErrorMessage = "Максимальное количество символов не должно превышать 18!")]
        public string Passport { get; set; }

        [MinLength(4, ErrorMessage = "Минимальное количество символов не менее 4!"), MaxLength(300, ErrorMessage = "Максимальное количество символов не должно превышать 300!")]
        public string Notes { get; set; }

        public string ResponsibleId { get; set; }

        public DateTime Creation { get; set; }
    }
}