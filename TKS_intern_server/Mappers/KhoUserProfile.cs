using AutoMapper;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.KhoUsers;

namespace TKS_intern_server.Mappers
{
    public class KhoUserProfile : Profile
    {
        public KhoUserProfile()
        {
            CreateMap<KhoUser, KhoUserSaveVM>().ReverseMap();
            CreateMap<KhoUser, KhoUserVM>();
        }
    }
}
