using AutoMapper;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.Khos;

namespace TKS_intern_server.Mappers
{
    public class KhoProfile : Profile
    {
        public KhoProfile()
        {
            CreateMap<Kho, KhoVM>().ReverseMap();
            CreateMap<KhoCreateVM, Kho>();
            CreateMap<KhoUpdateVM, Kho>();
        }
    }
}
