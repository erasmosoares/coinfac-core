using CoinFac.Application.Interfaces.Repositories;
using CoinFac.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;

namespace CoinFac.Persistence.Repositories.Accounts
{
    [TestFixture]
    public class AccountRepositoryTests
    {
        private Mock<IAccountRepository> _repository;


        public AccountRepositoryTests()
        {
            _repository = new Mock<IAccountRepository>();
        }

        [Test]
        [Ignore("NotImplemented")]
        public void GetAccountNameById_AccountIsProcessed_ThrowNotImplementedExeption()
        {
            //TODO Todo
            //Assert.Throws<NotImplementedException>(() => _repository.Object.GetAccountByNameAndUserId(1));
        }
    }
}
