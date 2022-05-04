using PiensaPeru.AdministratorService.Domain.Models;
using PiensaPeru.AdministratorService.Domain.Services.Communications;

namespace PiensaPeru.AdministratorService.Domain.Services
{
    public interface IAdministratorService
    {
        Task<IEnumerable<Administrator>> ListAsync();
        Task<AdministratorResponse> GetByIdAsync(int id);
        Task<AdministratorResponse> SaveAsync(Administrator administrator);
        Task<AdministratorResponse> UpdateAsync(int id, Administrator administrator);
        Task<AdministratorResponse> DeleteAsync(int id);
    }
}
