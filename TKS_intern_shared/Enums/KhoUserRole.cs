using System;

namespace TKS_intern_shared.Enums
{
    public enum KhoUserRole
    {
        QuanLy = 1,          // Quản lý kho
        ThuKho = 2,          // Thủ kho (người phụ trách nhập/xuất hàng)
        KeToan = 3,          // Kế toán (liên quan đến chứng từ, hóa đơn)
        NhanVien = 4,        // Nhân viên kho thông thường
        Khach = 5            // Người dùng chỉ có quyền xem
    }
}
