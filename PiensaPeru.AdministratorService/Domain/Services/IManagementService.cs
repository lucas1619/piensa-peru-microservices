using PiensaPeru.AdministratorService.Domain.Models;
using PiensaPeru.AdministratorService.Domain.Services.Communications;

namespace PiensaPeru.AdministratorService.Domain.Services
{
    public interface IManagementService
    {
        Task<IEnumerable<Management>> ListAsync();
        Task<IEnumerable<Management>> ListByAdministratorIdAsync(int administratorId);
        Task<ManagementResponse> GetByIdAsync(int id);
        Task<ManagementResponse> SaveAsync(int administratorId, int contentId, Management management);
        Task<ManagementResponse> UpdateAsync(int id, Management management);
        Task<ManagementResponse> DeleteAsync(int id);
    }
}
