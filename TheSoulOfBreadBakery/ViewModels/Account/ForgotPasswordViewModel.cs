using System.ComponentModel.DataAnnotations;

namespace TheSoulOfBreadBakery.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
