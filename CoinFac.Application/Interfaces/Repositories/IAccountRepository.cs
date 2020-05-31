using CoinFac.Domain.Accounts;
using System.Threading.Tasks;

namespace CoinFac.Application.Interfaces.Repositories
{
    public interface IAccountRepository :  IRepository<Account>
    {
        Task<Account> GetAccountByNameAndUserId(string accountName, int userId);

        Task<string> DeleteAccountByIdAsync(int accountId);
    }
}
