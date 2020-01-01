namespace CoinFac.Infrastructure.Network
{
    public interface IWebClientWrapper
    {
        void Post(string address, string json);
    }
}
