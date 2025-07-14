using System.ComponentModel.DataAnnotations;
using TKS_intern_shared.Models;

namespace TKS_intern_shared.ViewModels.DonViTinhs
{
    public class DonViTinhVM : BaseVM
    {
        public string TenDonViTinh { get; set; } = string.Empty;
        public string? GhiChu { get; set; } = null;
    }
}
    