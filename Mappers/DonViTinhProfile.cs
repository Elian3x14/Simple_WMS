using AutoMapper;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.DonViTinhs;


namespace TKS_intern_shared.Mappers
{
    public class DonViTinhProfile : Profile
    {
        public DonViTinhProfile()
        {
            CreateMap<DonViTinh, DonViTinhVM>().ReverseMap();
            CreateMap<DonViTinhCreateVM, DonViTinh>();
            CreateMap<DonViTinhUpdateVM, DonViTinh>();
        }
    }
}
