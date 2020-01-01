using System.Threading.Tasks;
using CoinFac.Application.Interfaces;
using CoinFac.Persistence.Repositories.Records;
using CoinFac.Persistence.Repositories.Accounts;
using CoinFac.Application.Interfaces.Repositories;
using CoinFac.Persistence.Repositories.Identities;


namespace CoinFac.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly ILogger<UnitOfWork> LogWriter;

        private readonly DatabaseService _context;

        public IRecordRepository RecordRepository { get; private set; }
        public IAccountRepository AccountRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }


        public UnitOfWork(DatabaseService context)
        {
            _context = context;

            RecordRepository = new RecordRepository(_context);

            AccountRepository = new AccountRepository(_context);

            UserRepository = new UserRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            int context;
            try
            {
                context =  await _context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                //TODO check null value
                // LogWriter.LogError(e, "Erreur d'enregistrement du contexte");

                throw;
            }

            return context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
