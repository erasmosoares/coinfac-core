using CoinFac.Domain.Identity;

namespace CoinFac.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        string GetUserNameById(int professionalId);
    }
}
