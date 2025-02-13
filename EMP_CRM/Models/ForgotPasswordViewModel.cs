using System.ComponentModel.DataAnnotations;

namespace EMP_CRM.ViewModels
{
    public class ForgotPasswordViewModel
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(50, MinimumLength = 3)]
        public string Email { get; set; }
    }
}
