using AutoMapper;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.Users;

namespace TKS_intern_server.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserVM>().ReverseMap();
        }
    }
}
