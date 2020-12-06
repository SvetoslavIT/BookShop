namespace BookShop.Web.Areas.Identity.Pages.Account
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using BookShop.Data.Models;
    using BookShop.Common;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.WebUtilities;
    using Microsoft.Extensions.Logging;

    using static BookShop.Common.ErrorMessages;
    using static BookShop.Common.GlobalConstants;

    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = NotRequire)]
            [EmailAddress(ErrorMessage = InvalidEmail)]
            [Display(Name = "Е-майл")]
            public string Email { get; set; }

            [Required(ErrorMessage = NotRequire)]
            [StringLength(100, ErrorMessage = InvalidPassword, MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Парола")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Потвъри паролата")]
            [Compare("Password", ErrorMessage = InvalidConfirmPassword)]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = NotRequire)]
            [StringLength(NameMaxLength, MinimumLength = DefaultMinLength, ErrorMessage = InvalidUserFullName)]
            [Display(Name = "Пълно име")]
            public string FullName { get; set; }

            [Required(ErrorMessage = NotRequire)]
            [StringLength(AddressMaxLength, MinimumLength = DefaultMinLength, ErrorMessage = InvalidAddress)]
            [Display(Name = "Адрес")]
            public string Address { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            this.ReturnUrl = returnUrl;
            this.ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= this.Url.Content("~/");
            this.ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            var user = new ApplicationUser
            {
                UserName = this.Input.Email,
                Email = this.Input.Email,
                FullName = this.Input.FullName,
                Address = this.Input.Address,
            };
            var result = await this.userManager.CreateAsync(user, this.Input.Password);

            if (result.Succeeded)
            {
                user.EmailConfirmed = true;
                await this.signInManager.PasswordSignInAsync(user, this.Input.Password, true, false);
                return this.LocalRedirect(returnUrl);
            }

            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError(string.Empty, error.Description);
            }

            return this.Page();
        }
    }
}
