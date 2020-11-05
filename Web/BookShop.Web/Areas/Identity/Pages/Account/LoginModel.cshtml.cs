namespace BookShop.Web.Areas.Identity.Pages.Account
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    using BookShop.Data.Models;
    using BookShop.Common;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;

        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = ErrorMessages.NotRequire)]
            [EmailAddress]
            [Display(Name = "E-майл")]
            public string Email { get; set; }

            [Required(ErrorMessage = ErrorMessages.NotRequire)]
            [DataType(DataType.Password)]
            [Display(Name = "Парола")]
            public string Password { get; set; }

            [Display(Name = "Запомни ме?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            returnUrl ??= this.Url.Content("~/");
            await this.HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            this.ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= this.Url.Content("~/");

            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            var result = await this.signInManager.PasswordSignInAsync(this.Input.Email, this.Input.Password, this.Input.RememberMe, false);
            if (result.Succeeded)
            {
                return this.LocalRedirect(returnUrl);
            }

            this.ModelState.AddModelError(string.Empty, ErrorMessages.InvalidLogin);

            return this.Page();
        }
    }
}
