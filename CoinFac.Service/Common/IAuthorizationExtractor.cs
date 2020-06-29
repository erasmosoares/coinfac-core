using Microsoft.AspNetCore.Http;

namespace CoinFac.Service.Common
{
    public interface IAuthorizationExtractor
    {
        int getUser(HttpRequest request);
    }
}
