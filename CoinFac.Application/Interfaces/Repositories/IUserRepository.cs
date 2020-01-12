using CoinFac.Domain.Identity;

namespace CoinFac.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByEmail(string email);
    }
}
