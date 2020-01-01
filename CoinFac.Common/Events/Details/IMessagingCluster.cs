using System;

namespace CoinFac.Common.Events.Details
{
    public interface IMessagingCluster
    {

        void Publish<TMessage>(TMessage message) where TMessage : IMessage;

        void Subscribe<TMessage>(Action<TMessage> action) where TMessage : IMessage;

        void UnSubscribe<TMessage>(ISubscription<TMessage> subscription) where TMessage : IMessage;

        void ClearAllSubscriptions();

        void ClearAllSubscriptions(Type[] exceptMessages);

    }
}
