using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using CoinFac.Domain.Accounts;
using CoinFac.Application.Interfaces;

namespace CoinFac.Application.Accounts.Queries.GetAccountDetail
{
    [TestFixture]
    public class GetAccountDetailQueryTests
    {
        [Test]
        public void GetAccountDetailQuery_WhenExecuteAsync_ReturnAnAccountDetailModel()
        {
            //Arrange
            var unitOfWork = new Mock<IUnitOfWork>();
            var getAccountDetailQuery = new GetAccountDetailQuery(unitOfWork.Object);

            var accountModel = new Account() { Id=1, Name = "Test" };
            
            unitOfWork.Setup<Task<Account>>(rep => rep.AccountRepository.GetAsync(1)).Returns(Task.FromResult(accountModel));

            //Act
            var result = getAccountDetailQuery.ExecuteAsync(1);

            //Assert
            Assert.That(result.Result.Name, Is.EqualTo("Test"));

        }
    }
}
