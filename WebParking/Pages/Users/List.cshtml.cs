using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using WebParking.Areas.Identity.Data;

namespace WebParking.Views.Users
{
    public class UsersPageModel : PageModel
    {
        private readonly UserManager<WebParkingUser> _userManager;

        public class UserListItemViewModel
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public string FirstName { get; internal set; }
            public string LastName { get; internal set; }
            public string MiddleName { get; internal set; }
        }

        public IList<UserListItemViewModel> UserList { get; set; }

        public UsersPageModel(UserManager<WebParkingUser> userManager)
        {
            _userManager = userManager;
        }

        public void OnGet()
        {
            UserList = _userManager.Users.Select(x => new UserListItemViewModel
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MiddleName = x.MiddleName
            }).ToList();
        }
    }
}
