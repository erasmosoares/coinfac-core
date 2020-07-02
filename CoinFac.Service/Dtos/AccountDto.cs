using CoinFac.Domain.Accounts;
using CoinFac.Service.Dtos;
using System.Collections.Generic;

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
        public List<RecordDto> Records { get; set; }
    }
}
