namespace PiensaPeru.UsersService.Resources
{
    public class UserResource : PersonResource
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool Subscribed { get; set; }
    }
}
