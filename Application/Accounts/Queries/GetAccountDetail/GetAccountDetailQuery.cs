using System.Threading.Tasks;
using CoinFac.Domain.Accounts;
using CoinFac.Application.Interfaces;

namespace CoinFac.Application.Accounts.Queries.GetAccountDetail
{
    public class GetAccountDetailQuery : IGetAccountDetailQuery
    {
        private readonly IUnitOfWork _database;

        public GetAccountDetailQuery(IUnitOfWork database)
        {
            _database = database;
        }
        public async Task<AccountDetailModel> ExecuteAsync(int accountId)
        {
            Account account = await _database.AccountRepository.GetAsync(accountId).ConfigureAwait(false);

            AccountDetailModel model = new AccountDetailModel()
            {
                Id = account.Id,
                Name = account.Name,
                Comments = account.Comments,
                Goal = account.Goal
            };

            return model;
        }
    }
}
