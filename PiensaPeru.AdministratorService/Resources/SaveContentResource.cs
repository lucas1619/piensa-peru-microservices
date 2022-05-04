using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.AdministratorService.Resources
{
    public class SaveContentResource
    {
        [Required]
        public bool Active { get; set; } = false;
    }
}
