using CoinFac.Domain.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoinFac.Application.Interfaces.Repositories
{
    public interface IAccountRepository :  IRepository<Account>
    {
        Task<IEnumerable<Account>> GetAccountsByUserIdAsync(int userId);

        Task<Account> GetAccountByNameAndUserId(string accountName, int userId);

        Task<string> DeleteAccountByIdAsync(int accountId);
    }
}
