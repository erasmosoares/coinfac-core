using System;

namespace CoinFac.Common.Events.Details
{
    public interface ISubscription<TMessage> : IDisposable where TMessage : IMessage
    {
        Action<TMessage> Action { get; }
        IMessagingCluster MessagingCluster { get; }
    }
}
