using CoinFac.Domain.Common;
using CoinFac.Domain.Identity;
using System.Collections.Generic;

namespace CoinFac.Domain.Accounts
{
    public class Account : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Goal { get; set; }
        public AccountType AccountType { get; set; }
        public string Comments { get; set; }
        public List<Record> Records { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

    public enum AccountType
    {
        Income,
        IncomeAndExpense,
        Expense
    }
}