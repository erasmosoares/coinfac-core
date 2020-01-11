using NUnit.Framework;
using System;

namespace CoinFac.Domain.Accounts
{
    [TestFixture]
    public class RecordTests
    {
        private int Id = 1;
        private int Value = 1;
        private DateTime Date = new DateTime();
        private string Notes = "";
        private int AccountForeignKey = 1;
        private Record Record = new Record();

        public RecordTests()
        {
            Record = new Record();
        }

        [Test]
        public void TestSetAndGetId()
        {
            Record.Id = Id;

            Assert.That(Record.Id, Is.EqualTo(Id));
        }

        [Test]
        public void TestSetAndGetValue()
        {
            Record.Value = Value;

            Assert.That(Record.Value, Is.EqualTo(Value));
        }

        [Test]
        public void TestSetAndGetDate()
        {
            Record.Date = Date;

            Assert.That(Record.Date, Is.EqualTo(Date));
        }

        [Test]
        public void TestSetAndGetNotes()
        {
            Record.Notes = Notes;

            Assert.That(Record.Notes, Is.EqualTo(Notes));
        }

        [Test]
        public void TestSetAndGetAccountForeignKey()
        {
            Record.AccountId = AccountForeignKey;

            Assert.That(Record.AccountId, Is.EqualTo(AccountForeignKey));
        }
    }
}
