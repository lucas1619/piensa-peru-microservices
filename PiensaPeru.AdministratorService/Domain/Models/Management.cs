namespace PiensaPeru.AdministratorService.Domain.Models
{
    public class Management
    {
        public int Id { get; set; }
        public DateTime SystemUpgrade { get; set; } = DateTime.Now;
        public string? ManagementType { get; set; }
        public int AdministratorId { get; set; }
        public Administrator? Administrator { get; set; }
        public int ContentId { get; set; }
        public Content? Content { get; set; }
    }
}
