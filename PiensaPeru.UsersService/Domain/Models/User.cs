namespace PiensaPeru.UsersService.Domain.Models
{
    public class User : Person
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool Subscribed { get; set; }
        public ICollection<Calification>? Califications { get; set; }
        public int PlanId { get; set; }
        public Plan? Plan { get; set; }
    }
}
