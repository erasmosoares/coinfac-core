using System.Threading.Tasks;

namespace CoinFac.Application.Accounts.Queries.GetAccountDetail
{
    public interface IGetAccountDetailQuery
    {
        Task<AccountDetailModel> ExecuteAsync(int accountId);
    }
}
