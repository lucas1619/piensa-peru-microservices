using PiensaPeru.AdministratorService.Domain.Models;

namespace PiensaPeru.AdministratorService.Domain.Persistence.Repositories
{
    public interface IManagementRepository
    {
        Task<IEnumerable<Management>> ListAsync();
        Task<IEnumerable<Management>> ListByAdministratorIdAsync(int administratorId);
        Task<Management> FindById(int id);
        Task AddAsync(Management management);
        void Update(Management management);
        void Remove(Management management);
    }
}
