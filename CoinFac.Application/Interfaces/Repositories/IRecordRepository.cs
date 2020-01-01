using System.Threading.Tasks;
using CoinFac.Domain.Accounts;
using System.Collections.Generic;

namespace CoinFac.Application.Interfaces.Repositories
{
    public interface IRecordRepository : IRepository<Record>
    {
        Task<IEnumerable<Record>> GetRecordByValueAsync(string name);
    }
}
