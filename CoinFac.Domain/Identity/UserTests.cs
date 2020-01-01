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

        [Test]
        public void TestSetAndGetFamilyName()
        {
            User.FamilyName = FamilyName;

            Assert.That(User.FamilyName, Is.EqualTo(FamilyName));
        }

        [Test]
        public void TestSetAndGetName()
        {
            User.Name = Name;

            Assert.That(User.Name, Is.EqualTo(Name));
        }

        [Test]
        public void TestSetAndGetPictureUrl()
        {
            User.PictureUrl = PictureUrl;

            Assert.That(User.PictureUrl, Is.EqualTo(PictureUrl));
        }

        [Test]
        public void TestSetAndGetLocale()
        {
            User.Locale = Locale;

            Assert.That(User.Locale, Is.EqualTo(Locale));
        }

        [Test]
        public void TestSetAndGetUpdatedAt()
        {
            User.UpdatedAt = UpdatedAt;

            Assert.That(User.UpdatedAt, Is.EqualTo(UpdatedAt));
        }

        [Test]
        public void TestSetAndGetEmail()
        {
            User.Email = Email;

            Assert.That(User.Email, Is.EqualTo(Email));
        }

        [Test]
        public void TestSetAndGetEmailVerified()
        {
            User.EmailVerified = EmailVerified;

            Assert.That(User.EmailVerified, Is.EqualTo(EmailVerified));
        }

        [Test]
        public void TestSetAndGetSub()
        {
            User.Sub = Sub;

            Assert.That(User.Sub, Is.EqualTo(Sub));
        }

        [Test]
        public void TestSetAndGetAccounts()
        {
            User.Accounts = Accounts;

            Assert.That(User.Accounts, Is.EqualTo(Accounts));
        }
    }
}
