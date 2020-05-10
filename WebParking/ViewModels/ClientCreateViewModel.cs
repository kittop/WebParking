using System.ComponentModel.DataAnnotations;
using System;//!
using System.ComponentModel;

namespace WebParking.ViewModels
{
    public class ClientCreateViewModel
    {
        [Required(ErrorMessage = "Имя не указано")]
        [MinLength(2), MaxLength(15)]
        public string FirstName { get; set; }

        [Required] public string LastName { get; set; }

        [Required] public string Telephone { get; set; }
        
        //[Required] public int Category { get; set; }

        [Required] public DateTime DateOfBirth { get; set; }

        [Required] public string Passport { get; set; }

        [Required] public string Notes { get; set; }

        [Required] public DateTime Creation { get; set; }
    }
}