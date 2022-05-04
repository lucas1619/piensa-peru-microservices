namespace PiensaPeru.AdministratorService.Domain.Models
{
    public class Content
    {
        public int Id { get; set; }
        public bool Active { get; set; } = false;
        public ICollection<Management>? Managements { get; set; }
    }
}
