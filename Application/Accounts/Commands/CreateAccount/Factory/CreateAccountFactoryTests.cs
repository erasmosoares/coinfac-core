using System;
using NUnit.Framework;
using CoinFac.Domain.Identity;
using CoinFac.Domain.Accounts;

namespace CoinFac.Application.Accounts.Commands.CreateAccount.Factory
{
    [TestFixture]
    public class CreateAccountFactoryTests
    {
        private readonly User User;
        private readonly CreateAccountModel CreateAccountModel;

        public CreateAccountFactoryTests()
        {
            CreateAccountModel = new CreateAccountModel()
            {
                Name = "Test",
                Comments = "CommentsTest",
                Goal = 50
            };

            User = new User()
            {
                Id = 1
            };
        }

        [Test]
        public void Create_WhenExecuteCreateWithUserNull_ReturnAnAccount()
        {
            //Arrange
            var factory = new CreateAccountFactory();

            //Act / Assert
            Assert.Throws<ArgumentNullException>(() => factory.Create(DateTime.Now, CreateAccountModel, null, AccountType.IncomeAndExpense));
        }

        [Test]
        public void Create_WhenExecuteCreateWithAccountNull_ReturnAnAccount()
        {
            //Arrange
            var factory = new CreateAccountFactory();

            //Act / Assert
            Assert.Throws<ArgumentNullException>(() => factory.Create(DateTime.Now, null, User, AccountType.IncomeAndExpense));
        }

        [Test]
        [TestCase(AccountType.Expense)]
        [TestCase(AccountType.Income)]
        [TestCase(AccountType.IncomeAndExpense)]
        public void Create_WhenExecuteCreate_ReturnAnAccount(AccountType accountType)
        {
            //Arrange
            var factory = new CreateAccountFactory();

            var accountToCompare = new Account()
            {
                Name = CreateAccountModel.Name,
                AccountType = accountType,
                Comments = CreateAccountModel.Comments,
                Goal = CreateAccountModel.Goal,
                Records = new System.Collections.Generic.List<Record>(),
                User = User,
                UserForeignKey = User.Id
            };

            //Act
            var account = factory.Create(DateTime.Now, CreateAccountModel, User, accountType);

            //Assert
            Assert.That(account.AccountType, Is.EqualTo(accountToCompare.AccountType));
        }

        [Test]
        public void Create_TestNameParameter_ReturnAnAccount()
        {
            //Arrange
            var factory = new CreateAccountFactory();

            var accountToCompare = new Account()
            {
                Name = CreateAccountModel.Name
            };

            //Act
            var account = factory.Create(DateTime.Now, CreateAccountModel, User, AccountType.IncomeAndExpense);

            //Assert
            Assert.That(account.Name, Is.EqualTo(accountToCompare.Name));
        }

        [Test]
        public void Create_TestCommentsParameter_ReturnAnAccount()
        {
            //Arrange
            var factory = new CreateAccountFactory();

            var accountToCompare = new Account()
            {
                Name = CreateAccountModel.Name
            };

            //Act
            var account = factory.Create(DateTime.Now, CreateAccountModel, User, AccountType.IncomeAndExpense);

            //Assert
            Assert.That(account.Comments, Is.EqualTo(accountToCompare.Comments));
        }

        [Test]
        public void Create_TestGoalParameter_ReturnAnAccount()
        {
            //Arrange
            var factory = new CreateAccountFactory();

            var accountToCompare = new Account()
            {
                Name = CreateAccountModel.Name
            };

            //Act
            var account = factory.Create(DateTime.Now, CreateAccountModel, User, AccountType.IncomeAndExpense);

            //Assert
            Assert.That(account.Goal, Is.EqualTo(accountToCompare.Goal));
        }

        [Test]
        public void Create_TestUserForeignKeyParameter_ReturnAnAccount()
        {
            //Arrange
            var factory = new CreateAccountFactory();

            var accountToCompare = new Account()
            {
                Name = CreateAccountModel.Name
            };

            //Act
            var account = factory.Create(DateTime.Now, CreateAccountModel, User, AccountType.IncomeAndExpense);

            //Assert
            Assert.That(account.UserForeignKey, Is.EqualTo(accountToCompare.UserForeignKey));
        }

        [Test]
        public void Create_TestAccountTypeParameter_ReturnAnAccount()
        {
            //Arrange
            var factory = new CreateAccountFactory();

            var accountToCompare = new Account()
            {
                Name = CreateAccountModel.Name
            };

            //Act
            var account = factory.Create(DateTime.Now, CreateAccountModel, User, AccountType.IncomeAndExpense);

            //Assert
            Assert.That(account.AccountType, Is.EqualTo(accountToCompare.AccountType));
        }
    }
}
