using System;
using CoinFac.Domain.Identity;
using CoinFac.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using CoinFac.Application.Interfaces.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace CoinFac.Persistence.Repositories.Identities
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            try
            {
                User userInDb = await DatabaseService.Users.FirstOrDefaultAsync(u => u.Email == email);
                return userInDb;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DatabaseService DatabaseService
        {
            get { return Context as DatabaseService; }
        }
    }
}
