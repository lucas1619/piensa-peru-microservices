using PiensaPeru.AdministratorService.Domain.Persistence.Contexts;
using PiensaPeru.AdministratorService.Domain.Persistence.Repositories;

namespace PiensaPeru.AdministratorService.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
