using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class NguoiDung
    {
        public int IdUser { get; set; }
        public int IdTypeUser { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string HoVaTen { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }

        public virtual KieuNguoiDung IdTypeUserNavigation { get; set; }
    }
}
