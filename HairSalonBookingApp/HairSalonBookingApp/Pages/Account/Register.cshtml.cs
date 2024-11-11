using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace HairSalonBookingApp.Pages.Account
{
    public class RegisterPageModel : PageModel
    {
        private readonly IAccountService _accountService;
        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();
        public string ReturnUrl { get; set; } = string.Empty;
        [TempData]
        public string ErrorMessage { get; set; } = string.Empty;

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; } = string.Empty;

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;

            public string? Name { get; set; }
        }

        public RegisterPageModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public void OnGet(string? returnUrl = null)
        {
            ReturnUrl = returnUrl ?? Url.Content("~/");

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                // Check if the user already exists
                var account = _accountService.Register(Input.Email, Input.Password, Input.Name, out string message);
                if (account == null)
                {
                    ModelState.AddModelError(string.Empty, message);
                    return Page();
                }

                // Automatically log the user in after registration
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                    new Claim(ClaimTypes.Name, account.Email),
                    new Claim(ClaimTypes.Role, account.RoleName)
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                return LocalRedirect(returnUrl);
            }

            return Page();
        }
    }
}
