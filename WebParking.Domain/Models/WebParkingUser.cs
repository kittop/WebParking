using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebParking.Domain.Models
{
    // Add profile data for application users by adding properties to the WebParkingUser class
    public class WebParkingUser : IdentityUser
    {
        [Required] 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
