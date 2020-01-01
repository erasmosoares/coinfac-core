using CoinFac.Domain.Accounts;
using CoinFac.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinFac.Domain.Identity
{
    public class User : IEntity
    {
        public int Id { get; set; }

        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string Locale { get; set; }
        public string UpdatedAt { get; set; }
        public string Email { get; set; }
        public string EmailVerified { get; set; }
        public string  Sub { get; set; }
        public List<Account> Accounts { get; set; }
    }
}

//User
//-------
//Id
//GivenName
//FamilyName
//Name
//PictureUrl
//Locale
//UpdatedAt
//Email
//EmailVerified
//Sub
