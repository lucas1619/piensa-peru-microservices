namespace PiensaPeru.AdministratorService.Domain.Models
{
    public class Administrator : Person
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public ICollection<Management>? Managements { get; set; }
    }
}
