using PiensaPeru.UsersService.Domain.Models;

namespace PiensaPeru.UsersService.Domain.Persistence.Repositories
{
    public interface IPlanRepository
    {
        Task<IEnumerable<Plan>> ListAsync();
        Task<Plan> FindById(int id);
        Task AddAsync(Plan plan);
        void Update(Plan plan);
        void Remove(Plan plan);
    }
}
