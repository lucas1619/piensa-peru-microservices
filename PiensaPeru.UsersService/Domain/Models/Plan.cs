namespace PiensaPeru.UsersService.Domain.Models
{
    public class Plan
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public DateTime ActivatedDate { get; set; } = DateTime.Now;
        public User? User { get; set; }
    }
}
