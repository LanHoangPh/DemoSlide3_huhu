using System.ComponentModel.DataAnnotations;

namespace DemoSlide3.Models.ViewModels
{
    public class EditRoleViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required(ErrorMessage ="Role khoong dc bo trong ")]
        public string RoleName { get; set; }
    }
}
