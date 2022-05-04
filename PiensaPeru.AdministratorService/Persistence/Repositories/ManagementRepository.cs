using Microsoft.EntityFrameworkCore;
using PiensaPeru.AdministratorService.Domain.Models;
using PiensaPeru.AdministratorService.Domain.Persistence.Contexts;
using PiensaPeru.AdministratorService.Domain.Persistence.Repositories;

namespace PiensaPeru.AdministratorService.Persistence.Repositories
{
    public class ManagementRepository : BaseRepository, IManagementRepository
    {
        public ManagementRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Management management)
        {
            await _context.Managements.AddAsync(management);
        }

        public async Task<Management> FindById(int id)
        {
            return await _context.Managements.FindAsync(id);
        }

        public async Task<IEnumerable<Management>> ListAsync()
        {
            return await _context.Managements.ToListAsync();
        }

        public async Task<IEnumerable<Management>> ListByAdministratorIdAsync(int administratorId)
        {
            return await _context.Managements
                .Where(s => s.AdministratorId == administratorId)
                .Include(s => s.Administrator)
                .ToListAsync();
        }

        public void Remove(Management management)
        {
            _context.Managements.Remove(management);
        }

        public void Update(Management management)
        {
            _context.Managements.Update(management);
        }
    }
}
