using System.Threading.Tasks;

namespace CoinFac.Application.Accounts.Commands.CreateAccount
{
    public interface ICreateAccountCommand
    {
        Task ExecuteAsync(CreateAccountModel model);
    }
}
