using AutoMapper;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.LoaiSanPhams;

namespace TKS_intern_shared.Mappers
{
    public class LoaiSanPhamProfile : Profile
    {
        public LoaiSanPhamProfile()
        {
            CreateMap<LoaiSanPham, LoaiSanPhamVM>().ReverseMap();
            CreateMap<LoaiSanPhamCreateVM, LoaiSanPham>();
            CreateMap<LoaiSanPhamUpdateVM, LoaiSanPham>();
        }
    }
}
