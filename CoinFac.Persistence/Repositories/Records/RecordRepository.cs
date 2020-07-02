using System.Threading.Tasks;
using CoinFac.Domain.Accounts;
using CoinFac.Persistence.Common;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CoinFac.Application.Interfaces.Repositories;
using System.Linq;

namespace CoinFac.Persistence.Repositories.Records
{
    public class RecordRepository : Repository<Record>, IRecordRepository
    {
        public RecordRepository(DbContext context) : base(context) { }

        public Task<IEnumerable<Record>> GetRecordByValueAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Record>> GetRecordsByAccountIdAsync(int accountId)
        {
            List<Record> recordsInDb = await DatabaseService.Records.Where(r => r.AccountId == accountId).ToListAsync();
            return recordsInDb;
        }

        public DatabaseService DatabaseService
        {
            get { return Context as DatabaseService; }
        }
    }
}
