using System.Threading.Tasks;
using CoinFac.Application.Interfaces.Repositories;

namespace CoinFac.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IRecordRepository RecordRepository { get; }
        IAccountRepository AccountRepository { get; }
        IUserRepository UserRepository { get; }

        Task<int> CompleteAsync();

        void Dispose();
    }
}
