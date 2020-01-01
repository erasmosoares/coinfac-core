using CoinFac.Domain.Identity;
using NUnit.Framework;
using System.Collections.Generic;

namespace CoinFac.Domain.Accounts
{
    [TestFixture]
    public class AccountTests
    {
        private readonly Account Account;
        private int Id = 1;
        private string Name = "Test";
        private int Goal = 50;
        private AccountType Types = AccountType.Expense;
        private string Comments = "Tests";
        private  List<Record> Records = new List<Record>() { new Record() };
        private User User = new User();

        public AccountTests()
        {
            Account = new Account();
        }

        [Test]
        public void TestSetAndGetId()
        {
            Account.Id = Id;

            Assert.That(Account.Id, Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetName()
        {
            Account.Name = Name;

            Assert.That(Account.Name, Is.EqualTo(Name));
        }

        [Test]
        public void TestSetAndGetGoal()
        {
            Account.Goal = Goal;

            Assert.That(Account.Goal, Is.EqualTo(Goal));
        }

        [Test]
        public void TestSetAndGetTypes()
        {
            Account.AccountType = Types;

            Assert.That(Account.AccountType, Is.EqualTo(Types));
        }

        [Test]
        public void TestSetAndGetComments()
        {
            Account.Comments = Comments;

            Assert.That(Account.Comments, Is.EqualTo(Comments));
        }

        [Test]
        public void TestSetAndGetRecords()
        {
            Account.Records = Records;

            Assert.That(Account.Records, Is.EqualTo(Records));
        }

        [Test]
        public void TestSetAndGetUser()
        {
            Account.User = User;

            Assert.That(Account.User, Is.EqualTo(User));
        }
    }
}
