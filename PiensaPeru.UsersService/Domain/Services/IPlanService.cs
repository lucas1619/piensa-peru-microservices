using PiensaPeru.UsersService.Domain.Models;
using PiensaPeru.UsersService.Domain.Services.Communications;

namespace PiensaPeru.UsersService.Domain.Services
{
    public interface IPlanService
    {
        Task<IEnumerable<Plan>> ListAsync();
        Task<PlanResponse> GetByIdAsync(int id);
        Task<PlanResponse> SaveAsync(Plan plan);
        Task<PlanResponse> UpdateAsync(int id, Plan plan);
        Task<PlanResponse> DeleteAsync(int id);
    }
}
