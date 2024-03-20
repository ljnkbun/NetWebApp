using Application.Commands.Users;
using Application.Models.Users;
using Application.Parameters.Users;
using Application.Queries.Users;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<CreateUserCommand, User>();
            CreateMap<GetUsersQuery, UserParameter>();
        }
    }
}
