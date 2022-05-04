namespace PiensaPeru.AdministratorService.Resources
{
    public class ManagementResource
    {
        public int Id { get; set; }
        public DateTime SystemUpgrade { get; set; }
        public string? ManagementType { get; set; }
        public int AdministratorId { get; set; }
        public int ContentId { get; set; }
    }
}
