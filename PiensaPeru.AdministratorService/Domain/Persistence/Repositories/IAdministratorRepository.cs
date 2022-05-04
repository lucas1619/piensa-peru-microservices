using PiensaPeru.AdministratorService.Domain.Models;

namespace PiensaPeru.AdministratorService.Domain.Persistence.Repositories
{
    public interface IAdministratorRepository
    {
        Task<IEnumerable<Administrator>> ListAsync();
        Task<Administrator> FindById(int id);
        Task AddAsync(Administrator administrator);
        void Update(Administrator administrator);
        void Remove(Administrator administrator);
    }
}
