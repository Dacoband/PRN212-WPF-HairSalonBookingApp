using HairSalonBookingApp.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HairSalonBookingApp.Pages.RegisterPage
{
    public class RegisterPageModel : PageModel
    {
        private readonly IAccountService _accountService;

        public RegisterPageModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; } = null!;

        [BindProperty]
        public string Password { get; set; } = null!;
        [BindProperty]
        public string ConfirmPassword { get; set; }

        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Please fill all field!";
                return Page();
            }
            if (!Password.Equals(ConfirmPassword))
            {
                ErrorMessage = "2 password are not the same!";
                return Page();
            }
            var isRegistered = await _accountService.RegisterAccount(Email, Password);
            if (!isRegistered)
            {
                ErrorMessage = "This Email is already exist!";
                return Page();
            }

            return RedirectToPage("/LoginPage/LoginPage");
        }
    }
}
