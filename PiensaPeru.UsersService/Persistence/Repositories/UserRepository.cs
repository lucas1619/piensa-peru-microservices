using Microsoft.EntityFrameworkCore;
using PiensaPeru.UsersService.Domain.Models;
using PiensaPeru.UsersService.Domain.Persistence.Contexts;
using PiensaPeru.UsersService.Domain.Persistence.Repositories;

namespace PiensaPeru.UsersService.Persistence.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> FindById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }
    }
}
