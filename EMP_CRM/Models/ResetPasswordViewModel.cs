using System.ComponentModel.DataAnnotations;

namespace EMP_CRM.ViewModels
{
    public class ResetPasswordViewModel
    {

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(50, MinimumLength = 3)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "Password must be between 8 to 10 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,10}$",
        ErrorMessage = "Password must contain at least one uppercase, one lowercase, one number, and one special character.")]
        public string NewPassword { get; set; }

        [Required, DataType(DataType.Password), Compare("NewPassword")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}
