using PiensaPeru.UsersService.Domain.Models;
using PiensaPeru.UsersService.Domain.Services.Communications;

namespace PiensaPeru.UsersService.Domain.Services
{
    public interface ICalificationService
    {
        Task<IEnumerable<Calification>> ListAsync();
        Task<IEnumerable<Calification>> ListByUserIdAsync(int userId);
        Task<CalificationResponse> GetByIdAsync(int id);
        Task<CalificationResponse> SaveAsync(int userId, Calification calification);
        Task<CalificationResponse> UpdateAsync(int id, Calification calification);
        Task<CalificationResponse> DeleteAsync(int id);
    }
}
