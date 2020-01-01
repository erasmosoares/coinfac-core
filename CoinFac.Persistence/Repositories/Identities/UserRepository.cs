using System;
using CoinFac.Domain.Identity;
using CoinFac.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using CoinFac.Application.Interfaces.Repositories;

namespace CoinFac.Persistence.Repositories.Identities
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }

        public string GetUserNameById(int professionalId)
        {
            throw new NotImplementedException();
        }
        public DatabaseService DatabaseService
        {
            get { return Context as DatabaseService; }
        }
    }
}
