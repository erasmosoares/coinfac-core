using AutoMapper;
using CoinFac.Domain.Accounts;
using CoinFac.Service.Models;

namespace CoinFac.Service.Profiles
{
    public class AccountProfiles : Profile
    {
        public AccountProfiles()
        {
            CreateMap<AccountDto, Account>();
            CreateMap<Account, AccountDto>();
        }
    }
}
