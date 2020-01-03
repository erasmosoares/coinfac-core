using Moq;
using System;
using NUnit.Framework;
using CoinFac.Common.Dates;
using CoreEvents.Interfaces;
using System.Threading.Tasks;
using CoinFac.Domain.Accounts;
using CoinFac.Common.Events.Details;
using CoinFac.Application.Interfaces;
using CoinFac.Common.Events.Messages;
using CoinFac.Application.Interfaces.Services;
using CoinFac.Application.Accounts.Commands.CreateAccount.Factory;

namespace CoinFac.Application.Accounts.Commands.CreateAccount
{
    [TestFixture]
    public class CreateAccountCommandTests
    {
        private Mock<IUnitOfWork> UnitOfWork;
        private Mock<IDateService> DateService;
        private Mock<ICreateAccountFactory> CreateAccountFactory;
        private Mock<IMessageService> MessageService;
        private Mock<IMessagingCluster> MessagingCluster;
        private Mock<ICoreEvents> CoreEvents;

        public CreateAccountCommandTests()
        {
            UnitOfWork = new Mock<IUnitOfWork>();
            DateService = new Mock<IDateService>();
            CreateAccountFactory = new Mock<ICreateAccountFactory>();
            MessageService = new Mock<IMessageService>();
            MessagingCluster = new Mock<IMessagingCluster>();
            CoreEvents = new Mock<ICoreEvents>();
        }

        [Test]
        public async Task CreateAccountCommand_WhenExecute_SaveInDatabase()
        {
            //Arrange
            DateService.Setup(ds => ds.GetDate()).Returns(DateTime.Now);
            UnitOfWork.Setup(uow => uow.AccountRepository.AddAsync(new Account())).Verifiable();
            UnitOfWork.Setup(uow => uow.CompleteAsync()).Verifiable();
            MessageService.Setup(ms => ms.NotifyService(1)).Verifiable();
            MessagingCluster.Setup(mc => mc.Publish(new MessageA())).Verifiable();
            CoreEvents.Setup(ce => ce.Publish(new MessageB())).Verifiable();
            var model = new CreateAccountModel() { Name = "Tests" };
            var command = new CreateAccountCommand(DateService.Object, UnitOfWork.Object, CreateAccountFactory.Object, MessageService.Object, MessagingCluster.Object, CoreEvents.Object);

            //Act
            await command.ExecuteAsync(model).ConfigureAwait(false);

            //Assert
            CreateAccountFactory.Setup(f => f.Create(DateService.Object.GetDate(), model, new Domain.Identity.User(), AccountType.IncomeAndExpense)).Verifiable();
        }
    }
}
