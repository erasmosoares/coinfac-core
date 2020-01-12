using Moq;
using System;
using NUnit.Framework;
using CoinFac.Application.Interfaces.Repositories;


namespace CoinFac.Persistence.Repositories.Identities
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private Mock<IUserRepository> _repository;

        public UserRepositoryTests()
        {
            _repository = new Mock<IUserRepository>();
        }

        [Test]
        [Ignore("NotImplemented")]
        public void GetAccountNameById_AccountIsProcessed_ThrowNotImplementedExeption()
        {
            Assert.Throws<NotImplementedException>(() => _repository.Object.GetUserByEmail(String.Empty));
        }
    }
}
