using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace CoinFac.Common.Events.Details
{
    public class MessagingCluster : IMessagingCluster
    {
        private readonly object _locker = new object();
       
        private readonly IDictionary<Type, IList> _subscriptions = new Dictionary<Type, IList>();

        public void Publish<TMessage>(TMessage message) where TMessage : IMessage
        {
            Padlock(() =>
            {
                if (message == null)
                    throw new ArgumentNullException("message");

                Type messageType = typeof(TMessage);
                if (_subscriptions.ContainsKey(messageType))
                {
                    var subscriptionList = new List<ISubscription<TMessage>>(
                        _subscriptions[messageType].Cast<ISubscription<TMessage>>());
                    foreach (var subscription in subscriptionList)
                        subscription.Action(message);
                }
            });

        }

        public void Subscribe<TMessage>(Action<TMessage> action) where TMessage : IMessage
        {
            Padlock(() =>
            {
                Type messageType = typeof(TMessage);
                var subscription = new Subscription<TMessage>(this, action);

                if (_subscriptions.ContainsKey(messageType))
                    _subscriptions[messageType].Add(subscription);
                else
                    _subscriptions.Add(messageType, new List<ISubscription<TMessage>> { subscription });
            });
        }

        public void UnSubscribe<TMessage>(ISubscription<TMessage> subscription) where TMessage : IMessage
        {
            Padlock(() =>
            {
                Type messageType = typeof(TMessage);
                if (_subscriptions.ContainsKey(messageType))
                    _subscriptions[messageType].Remove(subscription);
            });

        }

        public void ClearAllSubscriptions(Type[] exceptMessages)
        {
            Padlock(() =>
            {
                foreach (var messageSubscriptions in new Dictionary<Type, IList>(_subscriptions))
                {
                    bool canDelete = true;
                    if (exceptMessages != null)
                        canDelete = !exceptMessages.Contains(messageSubscriptions.Key);

                    if (canDelete)
                        _subscriptions.Remove(messageSubscriptions);
                }
            });
        }

        public void ClearAllSubscriptions()
        {
            ClearAllSubscriptions(null);
        }

        private void Padlock(Action action)
        {
            lock (_locker)
            {
                action();
            }
        }
    }
}
