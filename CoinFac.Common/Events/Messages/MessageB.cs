using CoreEvents.Interfaces;

namespace CoinFac.Common.Events.Messages
{
    public class MessageB : ICoreMessage
    {
        public string LogMessage { get; set; } = "Hello World";
    }
}
