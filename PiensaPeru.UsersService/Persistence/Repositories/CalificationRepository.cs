using Microsoft.EntityFrameworkCore;
using PiensaPeru.UsersService.Domain.Models;
using PiensaPeru.UsersService.Domain.Persistence.Contexts;
using PiensaPeru.UsersService.Domain.Persistence.Repositories;

namespace PiensaPeru.UsersService.Persistence.Repositories
{
    public class CalificationRepository : BaseRepository, ICalificationRepository
    {
        public CalificationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Calification calification)
        {
            await _context.Califications.AddAsync(calification);
        }

        public async Task<Calification> FindById(int id)
        {
            return await _context.Califications.FindAsync(id);
        }

        public async Task<IEnumerable<Calification>> ListAsync()
        {
            return await _context.Califications.ToListAsync();
        }

        public async Task<IEnumerable<Calification>> ListByUserIdAsync(int userId)
        {
            return await _context.Califications
                .Where(c => c.UserId == userId)
                .Include(c => c.User)
                .ToListAsync();
        }

        public void Remove(Calification calification)
        {
            _context.Califications.Remove(calification);
        }

        public void Update(Calification calification)
        {
            _context.Califications.Update(calification);
        }
    }
}
