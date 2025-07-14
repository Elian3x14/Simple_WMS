using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TKS_intern_shared.Models
{
    public class DonViTinh : BaseModel
    {
        public string TenDonViTinh { get; set; } = string.Empty;
        public string? GhiChu { get; set; } = null;

    }
}
