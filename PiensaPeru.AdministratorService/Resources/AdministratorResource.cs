namespace PiensaPeru.AdministratorService.Resources
{
    public class AdministratorResource : PersonResource
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
