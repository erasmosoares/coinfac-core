using CoinFac.Domain.Accounts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinFac.Domain.Identity
{
    [TestFixture]
    public class UserTests 
    {
        private int Id = 1;

        private string GivenName = "Erasmo";
        private string FamilyName = "Soares";
        private string Name = "Erasmo";
        private string PictureUrl = "www..";
        private string Locale = "Br";
        private string UpdatedAt = "10 sep";
        private string Email = "erasmosaraujo@gmail.com";
        private string EmailVerified = "True";
        private string Sub = "Sub";
        private List<Account> Accounts = new List<Account>() { new Account() };
        private User User = new User();

        public UserTests()
        {
            User = new User();
        }

        [Test]
        public void TestSetAndGetId()
        {
            User.Id = Id;

            Assert.That(User.Id, Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetGivenName()
        {
            User.GivenName = GivenName;

            Assert.That(User.GivenName, Is.EqualTo(GivenName));
        }
    }
}
