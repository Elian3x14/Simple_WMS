using AutoMapper;
using TKS_intern.Models;
using TKS_intern.ViewModels.DonViTinhs;

namespace TKS_intern.Mappers
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
