using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using CoinFac.Domain.Accounts;
using System.Collections.Generic;
using CoinFac.Application.Interfaces;

namespace CoinFac.Application.Accounts.Queries.GetAccountsList
{
    [TestFixture]
    public class GetAccountListQueryTests
    {
      
        [Test]
        public void GetAccountListQuery_WhenExecuteAsync_ReturnAListOfAccountModel()
        {
            //Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            var getAccountListQuery = new GetAccountListQuery(unitOfWork.Object);

            var accountModel = new Account() { Name = "Test" };
            var accountModelList = new List<Account>() { accountModel };
            IEnumerable<Account> accounts = accountModelList;

            unitOfWork.Setup<Task<IEnumerable<Account>>>(rep => rep.AccountRepository.GetAllAsync()
            ).Returns(Task.FromResult<IEnumerable<Account>>(accounts));

            //Act
            var result = getAccountListQuery.ExecuteAsync();

            //Assert
            Assert.That(result.Result[0].Name, Is.EqualTo("Test"));

        }
    }
}
