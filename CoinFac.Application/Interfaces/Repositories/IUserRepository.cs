using CoinFac.Domain.Identity;
using System.Threading.Tasks;

namespace CoinFac.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}
