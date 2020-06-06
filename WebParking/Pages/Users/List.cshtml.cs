using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using WebParking.Areas.Identity.Data;
using WebParking.Domain.Models;

namespace WebParking.Views.Users
{
    public class UsersPageModel : PageModel
    {
        private readonly UserManager<WebParkingUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public class UserListItemViewModel
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public bool IsAdmin { get; set; }
        }

        public IList<UserListItemViewModel> UserList { get; set; }

        public UsersPageModel(UserManager<WebParkingUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void OnGet()
        {
            UserList = _userManager.Users.Select(x => new UserListItemViewModel
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                MiddleName = x.MiddleName,
                IsAdmin = _userManager.IsInRoleAsync(x, Roles.AdminRole).Result
            }).ToList();
        }
    }
}
