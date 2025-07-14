using System.ComponentModel.DataAnnotations;
using TKS_intern.Models;

namespace TKS_intern.ViewModels.DonViTinhs
{
    public class DonViTinhVM : BaseVM
    {
        public string TenDonViTinh { get; set; } = string.Empty;
        public string? GhiChu { get; set; } = null;
    }
}
    