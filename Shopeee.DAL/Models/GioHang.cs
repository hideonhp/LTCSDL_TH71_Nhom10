using System;
using System.Collections.Generic;

namespace Shopeee.DAL.Models
{
    public partial class GioHang
    {
        public int IdGioHang { get; set; }
        public int IdSanPham { get; set; }
        public int IdUsers { get; set; }
        public int TrangThai { get; set; }
    }
}
