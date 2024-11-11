using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HairSalonBookingApp.Pages.LoginPage
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

        public LoginPageModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost(string handler)
        {
            if (handler == "register")
            {
                return RedirectToPage("/RegisterPage/RegisterPage");
            }

            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
            {
                var account = _accountService.Login(Email, Password);
                if (account != null)
                {
                    return RedirectToPage("/Index");
                }
                ErrorMessage = "Invalid email or password.";
            }
            return Page();
        }
    }
}
