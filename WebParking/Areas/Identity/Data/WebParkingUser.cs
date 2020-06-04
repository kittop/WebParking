using Microsoft.AspNetCore.Identity;

namespace WebParking.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the WebParkingUser class
    public class WebParkingUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }
    }
}
