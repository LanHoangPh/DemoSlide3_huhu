using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace DemoSlide3.Models.ViewModels
{
    public class EditViewModel
    {
        public string Id { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
