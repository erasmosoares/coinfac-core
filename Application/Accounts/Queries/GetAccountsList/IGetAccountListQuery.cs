using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoinFac.Application.Accounts.Queries.GetAccountsList
{
    public interface IGetAccountListQuery
    {
        Task<List<AccountModel>> ExecuteAsync();
    }
}
