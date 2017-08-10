using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_X_2._0.Entities
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Entered phone format is not valid. Valid format: 9876543210")]
        [Display(Name = "Phone no.*")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Email*")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name*")]
        //[Index(IsUnique = true)]        //implement this in IdentityUSer class
        public string UserName { get; set; }

        //[Required]
        [Display(Name = "Email*")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password*")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User Name*")]
        //[Index(IsUnique = true)]        //implement this in IdentityUSer class
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email*")]
        public string Email { get; set; }

        //[RegularExpression(@"^(\+\d{2,3}[\-\s]?)?\d{10}$", ErrorMessage = "Entered phone format is not valid. Valid format: +91-9999999999)], for isd numbers
        //[RegularExpression(@"^(\+91[\-\s]?)?\d{10}$", ErrorMessage = "Entered phone format is not valid. Valid format: +91-9999999999 or ")], for indian numbers
        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Entered phone format is not valid. Valid format: 9876543210")]
        [Display(Name = "Phone no.*")]
        public string PhoneNumber { get; set; }

        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password*")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password*")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
