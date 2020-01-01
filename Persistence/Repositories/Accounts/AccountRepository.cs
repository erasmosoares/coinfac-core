using System;
using CoinFac.Domain.Accounts;
using CoinFac.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using CoinFac.Application.Interfaces.Repositories;

namespace CoinFac.Persistence.Repositories.Accounts
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(DbContext context) : base(context) { }

        public string GetAccountNameById(int medicamentId)
        {
            throw new NotImplementedException();
        }
        public DatabaseService DatabaseService
        {
            get { return Context as DatabaseService; }
        }
    }
}
