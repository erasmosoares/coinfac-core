using CoinFac.Application.Interfaces.Repositories;
using Moq;
using NUnit.Framework;
using System;

namespace CoinFac.Persistence.Repositories.Records
{
    [TestFixture]
    public class RecordRepositoryTests
    {
        private Mock<IRecordRepository> _repository;

        public RecordRepositoryTests()
        {
            _repository = new Mock<IRecordRepository>();
        }

        [Test]
        public void GetRecordByValueAsync_AccountIsProcessed_ThrowNotImplementedExeption()
        {
            Assert.Throws<NotImplementedException>(() => _repository.Object.GetRecordByValueAsync("2"));
        }
    }
}
