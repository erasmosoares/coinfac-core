using System;
using CoinFac.Domain.Accounts;
using CoinFac.Persistence.Common;
using Microsoft.EntityFrameworkCore;
using CoinFac.Application.Interfaces.Repositories;
using System.Threading.Tasks;

namespace CoinFac.Persistence.Repositories.Accounts
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(DbContext context) : base(context) { }

        public async Task<Account> GetAccountByNameAndUserId(string accountName, int userId)
        {
            try
            {
                Account accountInDb = await DatabaseService.Accounts.FirstOrDefaultAsync(a => a.Name == accountName && a.UserId == userId);
                return accountInDb;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> DeleteAccountByIdAsync(int accountId)
        {
            Account accountInDb = await DatabaseService.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
            
            if (accountInDb != null) {
                DatabaseService.Accounts.Remove(accountInDb);
                return accountInDb.Name;
            }

            return string.Empty;
        }

        public DatabaseService DatabaseService
        {
            get { return Context as DatabaseService; }
        }
    }
}
