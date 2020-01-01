using System;
using CoinFac.Domain.Accounts;
using CoinFac.Domain.Identity;

namespace CoinFac.Application.Accounts.Commands.CreateAccount.Factory
{
    public interface ICreateAccountFactory
    {
        Account Create(DateTime creationDate, CreateAccountModel model, User user, AccountType type);
    }
}
