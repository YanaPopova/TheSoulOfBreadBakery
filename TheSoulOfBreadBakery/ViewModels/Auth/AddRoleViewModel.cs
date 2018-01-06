using System.ComponentModel.DataAnnotations;

namespace TheSoulOfBreadBakery.ViewModels.Auth
{
    public class AddRoleViewModel
    {
        [Required]
        [Display(Name = "Role name")]
        public string RoleName { get; set; }
    }
}
