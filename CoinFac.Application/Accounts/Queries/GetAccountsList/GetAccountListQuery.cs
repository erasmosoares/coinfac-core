using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using CoinFac.Application.Interfaces;

namespace CoinFac.Application.Accounts.Queries.GetAccountsList
{
    public class GetAccountListQuery : IGetAccountListQuery
    {
        private readonly IUnitOfWork _database;

        public GetAccountListQuery(IUnitOfWork database)
        {
            _database = database;
        }

        public async Task<List<AccountModel>> ExecuteAsync()
        {
            var accounts = await _database.AccountRepository.GetAllAsync().ConfigureAwait(false);

            var model = accounts.Select(p => new AccountModel()
            {
                Id = p.Id,
                Name = p.Name
            });

            return model.ToList();
        }
    }
}
