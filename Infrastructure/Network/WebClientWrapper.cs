using System.Net;

namespace CoinFac.Infrastructure.Network
{
    public class WebClientWrapper : IWebClientWrapper
    {
        public void Post(string address, string json)
        {
            //using (var client = new WebClient())
            //{
            //    client.Headers[HttpRequestHeader.ContentType] = "application/json";
            //    client.UploadString(address, "POST", json);
            //}
        }
    }
}
