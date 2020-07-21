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



            CreateMap<RecordDto, Record>()
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Amount));
            
            CreateMap<Record, RecordDto>()
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Value))
            .ForPath(dest => dest.Account, opt => opt.MapFrom(src => src.Account.Name));
        }
    }
}
