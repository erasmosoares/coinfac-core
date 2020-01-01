using CoinFac.Domain.Common;

namespace CoinFac.Domain.Accounts
{
    public class Account : IEntity
    {
        public int Id { get; set; }
    }
}

//Accounts
//-----
//Id
//Name
//Goal
//Type
//{ Income, Income/Expense, Expense }
//Comments