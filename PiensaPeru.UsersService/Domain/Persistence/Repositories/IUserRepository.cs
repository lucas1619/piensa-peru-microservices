using PiensaPeru.UsersService.Domain.Models;

namespace PiensaPeru.UsersService.Domain.Persistence.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> ListAsync();
        Task<User> FindById(int id);
        Task AddAsync(User user);
        void Update(User user);
        void Remove(User user);
    }
}
