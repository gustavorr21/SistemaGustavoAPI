using Sistema.Repository.Repositorys.Geral;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Domain.Identity;

namespace Sistema.Repository.Repositorys.Usuario
{
    public interface IUserRepository : IGeralRepository
    {
        Task<IEnumerable<User>> GetUserAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByNameAsync(string name);
    }
}
