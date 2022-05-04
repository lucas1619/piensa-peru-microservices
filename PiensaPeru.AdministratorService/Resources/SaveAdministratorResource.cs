using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.AdministratorService.Resources
{
    public class SaveAdministratorResource : SavePersonResource
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
