using AutoMapper;
using BlogApp.Dtos;
using BlogApp.Entity;

namespace BlogApp.utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 
           CreateMap<User,UserDto>().ReverseMap();
        }
    }
}
