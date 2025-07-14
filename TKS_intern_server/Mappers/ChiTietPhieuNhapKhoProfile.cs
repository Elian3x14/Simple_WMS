using AutoMapper;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.ChiTietPhieuNhapKhos;

namespace TKS_intern_server.Mappers
{
    public class ChiTietPhieuNhapKhoProfile : Profile
    {
        public ChiTietPhieuNhapKhoProfile()
        {
            CreateMap<ChiTietPhieuNhapKho, ChiTietPhieuNhapKhoSaveVM>().ReverseMap();
            CreateMap<ChiTietPhieuNhapKho, ChiTietPhieuNhapKhoVM>().ReverseMap();
        }
    }
}
