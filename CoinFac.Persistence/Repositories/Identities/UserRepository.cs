using System;
using CoinFac.Domain.Identity;
using CoinFac.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using CoinFac.Application.Interfaces.Repositories;
using System.Linq;

namespace CoinFac.Persistence.Repositories.Identities
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }

        public User GetUserByEmail(string email)
        {
            try
            {
                var userInDb = DatabaseService.Users.Where(u => u.Email == email).FirstOrDefault();
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
