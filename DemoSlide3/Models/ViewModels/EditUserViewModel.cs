using System.ComponentModel.DataAnnotations;

namespace DemoSlide3.Models.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
