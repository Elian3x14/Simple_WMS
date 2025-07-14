using AutoMapper;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.SanPhams;

namespace TKS_intern_shared.Mappers
{
    public class SanPhamProfile : Profile
    {
        public SanPhamProfile()
        {
            CreateMap<SanPham, SanPhamVM>().ReverseMap();
            CreateMap<SanPhamCreateVM, SanPham>();
            CreateMap<SanPhamUpdateVM, SanPham>();
        }
    }
}
