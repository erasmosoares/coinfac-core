using CoinFac.Application.Accounts.Commands.CreateAccount.Factory;
using CoinFac.Application.Interfaces;
using CoinFac.Application.Interfaces.Services;
using CoinFac.Common.Dates;
using CoinFac.Common.Events.Details;
using CoinFac.Common.Events.Messages;
using CoinFac.Domain.Identity;
using CoreEvents.Interfaces;
using System.Threading.Tasks;

namespace CoinFac.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountCommand : ICreateAccountCommand
    {
        private readonly IDateService DateService;
        private readonly IUnitOfWork UnitOfWork;
        private readonly ICreateAccountFactory Factory;

        private readonly IMessageService MessageService;
        private readonly IMessagingCluster Messaging;
        private readonly ICoreEvents CoreEvent;

        public CreateAccountCommand(
            IDateService dateService,
            IUnitOfWork unitOfWork,
            ICreateAccountFactory factory,
            IMessageService messageService,
            IMessagingCluster messaging,
            ICoreEvents coreEvent)
        {
            DateService = dateService;
            UnitOfWork = unitOfWork;
            Factory = factory;
            MessageService = messageService;
            Messaging = messaging;
            CoreEvent = coreEvent;
        }

        public async Task ExecuteAsync(CreateAccountModel model)
        {
            var date = DateService.GetDate();
            var user = new User();

            var account = Factory.Create(date, model, user, Domain.Accounts.AccountType.IncomeAndExpense);

            await UnitOfWork.AccountRepository.AddAsync(account).ConfigureAwait(false);
            await UnitOfWork.CompleteAsync().ConfigureAwait(false);

            if(account != null)
               MessageService.NotifyService(account.Id);

            Messaging.Publish(new MessageA());

            CoreEvent.Publish(new MessageB());
        }
    }
}
