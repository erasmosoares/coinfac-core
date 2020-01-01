using CoinFac.Domain.Common;
using System;

namespace CoinFac.Domain.Accounts
{
    public class Record : IEntity
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public DateTime Date { get; set; }

        public string Notes { get; set; }

        public int AccountForeignKey { get; set; }
        public Account Account { get; set; }
    }
}