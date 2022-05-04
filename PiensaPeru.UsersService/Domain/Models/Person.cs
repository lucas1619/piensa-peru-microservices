namespace PiensaPeru.UsersService.Domain.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? PersonType { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
