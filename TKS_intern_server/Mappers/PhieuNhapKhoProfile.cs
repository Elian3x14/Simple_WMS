using AutoMapper;
using TKS_intern_shared.Models;
using TKS_intern_shared.ViewModels.PhieuNhapKhos;

namespace TKS_intern_server.Mappers
{
    public class PhieuNhapKhoProfile : Profile
    {
        public PhieuNhapKhoProfile()
        {
            CreateMap<PhieuNhapKho, PhieuNhapKhoVM>().ReverseMap();
            CreateMap<PhieuNhapKhoSaveVM, PhieuNhapKho>();
        }
    }
}
