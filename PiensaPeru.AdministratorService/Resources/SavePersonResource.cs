using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.AdministratorService.Resources
{
    public class SavePersonResource
    {
        [Required]
        [MaxLength(30)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string? LastName { get; set; }
    }
}