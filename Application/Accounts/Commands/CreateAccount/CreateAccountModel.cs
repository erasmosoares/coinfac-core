using CoinFac.Domain.Accounts;
using System.ComponentModel.DataAnnotations;

namespace CoinFac.Application.Accounts.Commands.CreateAccount
{
    public class CreateAccountModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Goal { get; set; }
        public string Comments { get; set; }       
    }
}

