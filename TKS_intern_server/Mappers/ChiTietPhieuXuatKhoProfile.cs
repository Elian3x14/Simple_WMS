using AutoMapper;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.ChiTietPhieuXuatKhos;

namespace TKS_intern_server.Mappers
{
    public class ChiTietPhieuXuatKhoProfile : Profile
    {
        public ChiTietPhieuXuatKhoProfile()
        {
            CreateMap<ChiTietPhieuXuatKhoSaveVM, ChiTietPhieuXuatKho>();
            CreateMap<ChiTietPhieuXuatKho, ChiTietPhieuXuatKhoVM>();
        }
    }
}
