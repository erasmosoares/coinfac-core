using AutoMapper;
using CoinFac.Domain.Accounts;
using CoinFac.Domain.Identity;
using CoinFac.Service.Dtos;
using CoinFac.Service.Models;

namespace CoinFac.Service.Profiles
{
    public class AccountProfiles : Profile
    {
        public AccountProfiles()
        {
            CreateMap<AccountDto, Account>();
            CreateMap<Account, AccountDto>();

            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
    }
}
