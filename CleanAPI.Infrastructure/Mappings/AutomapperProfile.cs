using AutoMapper;
using CleanAPI.Core.DTOs;
using CleanAPI.Core.Entities;

namespace CleanAPI.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, UserLoginDto>().ReverseMap();
            CreateMap<User, UserfilterDto>().ReverseMap();
        }
    }
}
