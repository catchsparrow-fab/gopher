using System.ComponentModel.DataAnnotations;
using Gopher.Model.Domain;
using Gopher.Model.Tools;

namespace Gopher.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [TranslatableDisplayName("Account_OldPassword")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [TranslatableDisplayName("Account_NewPassword")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        [TranslatableDisplayName("Account_ConfirmNewPassword")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [TranslatableDisplayName("Generic_Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [TranslatableDisplayName("Generic_Password")]
        public string Password { get; set; }

        [TranslatableDisplayName("Login_RememberMe")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class PreferencesViewModel
    {
        public User User { get; set; }
    }
}
