using CoinFac.Domain.Accounts;
using System.Threading.Tasks;

namespace CoinFac.Application.Interfaces.Repositories
{
    public interface IAccountRepository :  IRepository<Account>
    {
        string GetAccountNameById(int accountId);

        Task<string> DeleteAccountByIdAsync(int accountId);
    }
}
