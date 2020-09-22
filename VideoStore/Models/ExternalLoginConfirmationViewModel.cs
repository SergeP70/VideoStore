using System.ComponentModel.DataAnnotations;

namespace VideoStore.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        public string Mobile { get; set; }
    }
}
