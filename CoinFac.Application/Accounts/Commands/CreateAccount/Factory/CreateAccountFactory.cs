using System;
using CoinFac.Domain.Accounts;
using CoinFac.Domain.Identity;

namespace CoinFac.Application.Accounts.Commands.CreateAccount.Factory
{
    public class CreateAccountFactory : ICreateAccountFactory
    {

        public Account Create(DateTime creationDate, CreateAccountModel model, User user, AccountType type)
        {
            if (model is null) 
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var account = new Account()
            {
                Name = model.Name,
                AccountType = type,
                Comments = model.Comments,
                Goal = model.Goal,
                Records = new System.Collections.Generic.List<Record>(),
                User = user,
                UserId = user.Id
            };

            return account;
        }
    }
}
