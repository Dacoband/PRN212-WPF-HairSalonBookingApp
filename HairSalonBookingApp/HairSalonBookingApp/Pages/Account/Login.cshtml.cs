using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace HairSalonBookingApp.Pages.Account
{
    public class LoginPageModel : PageModel
    {
        private readonly IAccountService _accountService;

        [BindProperty]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; } = string.Empty;

        [BindProperty]
        public string? Password { get; set; } = string.Empty;

        public string? ErrorMessage { get; set; }
        public string ReturnUrl { get; set; } = string.Empty;

        public LoginPageModel(IAccountService accountService)
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

        public async Task<IActionResult> OnPost(string handler, string? returnUrl = null)
        {
            if (handler == "register")
            {
                return RedirectToPage("./Register");
            }

            returnUrl ??= Url.Content("~/");

            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
            {
                var (account, message) = await _accountService.Login(Email, Password);

                if (account == null)
                {
                    ModelState.AddModelError(string.Empty, message);
                    return Page();
                }

                
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, account.Id.ToString()),
                    new Claim(ClaimTypes.Name, account.Email),
                    new Claim(ClaimTypes.Role, account.RoleName) 
                };

                // Create identity
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Create principal
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Sign in the user
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                if (account.RoleName == "Admin")
                {
                    returnUrl = Url.Content("~/AdminPage/ListFunctions");
                }
                if (account.RoleName == "Customer")
                {
                    returnUrl = Url.Content("~/ServicePage/List");
                }


                return Redirect(returnUrl);
            }

            return Page();
        }
    }
}
