using CoinFac.Domain.Accounts;
using CoinFac.Service.Dtos;

namespace CoinFac.Service.Models
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Goal { get; set; }
        public AccountType AccountType { get; set; }
        public string Comments { get; set; }
        public int UserId { get; set; }
    }
}
