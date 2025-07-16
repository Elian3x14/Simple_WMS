using AutoMapper;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.PhieuXuatKhos;

namespace TKS_intern_server.Mappers
{
    public class PhieuXuatKhoProfile : Profile
    {
        public PhieuXuatKhoProfile()
        {
            CreateMap<PhieuXuatKho, PhieuXuatKhoVM>();
            CreateMap<PhieuXuatKhoCreateVM, PhieuXuatKho>();
            CreateMap<PhieuXuatKhoSaveVM, PhieuXuatKho>();
        }
    }
}
