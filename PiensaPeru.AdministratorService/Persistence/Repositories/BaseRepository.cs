using PiensaPeru.AdministratorService.Domain.Persistence.Contexts;

namespace PiensaPeru.AdministratorService.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
