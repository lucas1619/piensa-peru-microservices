using PiensaPeru.UsersService.Domain.Persistence.Contexts;
using PiensaPeru.UsersService.Domain.Persistence.Repositories;

namespace PiensaPeru.UsersService.Persistence.Repositories
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
