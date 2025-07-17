using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TKS_intern_shared.ViewModels.Auth
{
    public class TokenVM
    {
        public required string AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
