using AutoMapper;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.NhaCungCaps;

namespace TKS_intern_server.Mappers
{
    public class NhaCungCapProfile : Profile
    {
        public NhaCungCapProfile()
        {
            CreateMap<NhaCungCap, NhaCungCapVM>().ReverseMap();
            CreateMap<NhaCungCapCreateVM, NhaCungCap>();
            CreateMap<NhaCungCapUpdateVM, NhaCungCap>();
        }
    }
}
