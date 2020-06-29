using System;
using System.Text;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace CoinFac.Service.Common
{
    public class AuthorizationExtractor : IAuthorizationExtractor
    {
        public int getUser(HttpRequest request)
        {
            var authHeader = AuthenticationHeaderValue.Parse(request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
            
            //var username = credentials[0];
            //var password = credentials[1];

            return Convert.ToInt32(credentials[0]);
        }
    }
}
