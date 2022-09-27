using Microsoft.EntityFrameworkCore;
using Sistema.Domain.Identity;
using Sistema.Repository.Data;
using Sistema.Repository.Repositorys.Geral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Repository.Repositorys.Usuario
{
    public class UserRepository : GeralRepository, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUserAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            var aa = await _context.Users.
                            SingleOrDefaultAsync(u => u.UserName == name.ToLower());
            return await _context.Users.
                            SingleOrDefaultAsync(u=>u.UserName == name.ToLower());
        }
    }
}
