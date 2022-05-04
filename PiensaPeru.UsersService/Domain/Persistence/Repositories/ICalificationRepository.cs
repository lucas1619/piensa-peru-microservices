using PiensaPeru.UsersService.Domain.Models;

namespace PiensaPeru.UsersService.Domain.Persistence.Repositories
{
    public interface ICalificationRepository
    {
        Task<IEnumerable<Calification>> ListAsync();
        Task<IEnumerable<Calification>> ListByUserIdAsync(int userId);
        Task<Calification> FindById(int id);
        Task AddAsync(Calification calification);
        void Update(Calification calification);
        void Remove(Calification calification);
    }
}
