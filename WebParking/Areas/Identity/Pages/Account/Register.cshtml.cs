using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using WebParking.Areas.Identity.Data;
using WebParking.Domain.Models;

namespace WebParking.Areas.Identity.Pages.Account
{
    [Authorize(Roles = Roles.AdminRole)]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<WebParkingUser> _signInManager;
        private readonly UserManager<WebParkingUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<WebParkingUser> userManager,
            SignInManager<WebParkingUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Укажите фамилию!")]
            [Display(Name = "Фамилия")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Укажите имя!")]
            [Display(Name = "Имя")]
            public string FirstName { get; set; }

            [Display(Name = "Отчество")]
            public string MiddleName { get; set; }

            [Required(ErrorMessage = "Укажите Email!")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Администратор")]
            public bool IsAdmin { get; set; }

            [Required(ErrorMessage = "Укажите пароль!")]
            [StringLength(100, ErrorMessage = "{0} должно быть не менее {2} и не более {1} символов.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Пароль")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Подтвердите пароль")]
            [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new WebParkingUser { UserName = Input.Email, Email = Input.Email, LastName = Input.LastName, FirstName = Input.FirstName, MiddleName = Input.MiddleName};
                var result = await _userManager.CreateAsync(user, Input.Password);
              

                if (result.Succeeded)
                {
                    _logger.LogInformation("Пользователь создал новую учетную запись с паролем.");
                
                    if (Input.IsAdmin)
                    {
                        var result2 = await _userManager.AddToRoleAsync(user, Roles.AdminRole);
                        if (result2.Succeeded)
                        {
                            _logger.LogInformation("Пользователь овладел правами.");
                        }
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return RedirectToPage("Identity", "Users", "List");
        }
    }
}
