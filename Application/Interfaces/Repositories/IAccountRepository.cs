using CoinFac.Domain.Accounts;

namespace CoinFac.Application.Interfaces.Repositories
{
    public interface IAccountRepository :  IRepository<Account>
    {
        string GetAccountNameById(int medicamentId);
    }
}
