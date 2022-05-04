using PiensaPeru.UsersService.Domain.Models;
using PiensaPeru.UsersService.Domain.Services.Communications;

namespace PiensaPeru.UsersService.Domain.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> GetByIdAsync(int id);
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(int id, User user);
        Task<UserResponse> DeleteAsync(int id);
    }
}
