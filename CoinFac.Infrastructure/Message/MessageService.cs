using System;
using CoreEvents.Interfaces;
using CoinFac.Application.Interfaces.Services;
using CoinFac.Infrastructure.Network;
using CoinFac.Common.Events.Details;
using CoinFac.Common.Events.Messages;

namespace CoinFac.Infrastructure.Message
{
    //Fake
    public class MessageService : IMessageService
    {
        private const string AddressTemplate = "http://abc.com/{0}/notify/";
        private const string JsonTemplate = "{{\"prescription\": {0}}}";

        private readonly IWebClientWrapper _client;
        private readonly IMessagingCluster _messaging;
        private readonly ICoreEvents _coreEvent;

        public MessageService(IWebClientWrapper client, IMessagingCluster messaging, ICoreEvents coreEvent)
        {
            _client = client;
            _messaging = messaging;
            _coreEvent = coreEvent;

            _messaging.Subscribe<MessageA>(c => { MessageANotification(c); });

            _coreEvent.Subscribe<MessageB>(c => { MessageBNotification(c); });
        }

        public void NotifyService(int prescriptionId)
        {
            var address = string.Format(AddressTemplate, prescriptionId);

            var json = string.Format(JsonTemplate, prescriptionId);

            _client.Post(address, json);
        }

        private void MessageANotification(MessageA message)
        {
            Console.WriteLine($"A Received a notification from: {message.LogMessage}");
        }

        private void MessageBNotification(MessageB message)
        {
            Console.WriteLine($"A Received a notification from: {message.LogMessage}");
        }
    }
}
