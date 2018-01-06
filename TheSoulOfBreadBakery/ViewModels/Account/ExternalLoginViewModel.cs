using System.ComponentModel.DataAnnotations;

namespace TheSoulOfBreadBakery.ViewModels.Account
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
