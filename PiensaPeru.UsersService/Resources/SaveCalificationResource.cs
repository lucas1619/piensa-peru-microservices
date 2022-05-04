using System.ComponentModel.DataAnnotations;

namespace PiensaPeru.UsersService.Resources
{
    public class SaveCalificationResource
    {
        [Required]
        public int Score { get; set; }
    }
}
