using System.ComponentModel.DataAnnotations;

namespace WebParking.ViewModels
{
    public class ClientCreateViewModel
    {
        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }
    }
}