using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.UsersService.Resources
{
    public class SaveUserResource : SavePersonResource
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public bool Subscribed { get; set; }
    }
}
