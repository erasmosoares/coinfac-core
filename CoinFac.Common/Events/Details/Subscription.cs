using System;

namespace CoinFac.Common.Events.Details
{
    public class Subscription<TMessage> : ISubscription<TMessage>where TMessage : IMessage
    {
        public Action<TMessage> Action { get; private set; }
        public IMessagingCluster MessagingCluster { get; private set; }

        public Subscription(IMessagingCluster eventAggregator, Action<TMessage> action)
        {
            MessagingCluster = eventAggregator ?? throw new ArgumentNullException("eventAggregator");
            Action = action ?? throw new ArgumentNullException("action");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                MessagingCluster.UnSubscribe(this);
        }
    }
}
