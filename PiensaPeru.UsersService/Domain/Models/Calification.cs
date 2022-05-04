using PiensaPeru.UsersService.Domain.Models;

namespace PiensaPeru.UsersService.Domain.Models
{
    public class Calification
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public DateTime ShipDate { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
