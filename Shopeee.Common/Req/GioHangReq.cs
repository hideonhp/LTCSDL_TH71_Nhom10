using System;
using System.Collections.Generic;
using System.Text;

namespace Shopeee.Common.Req
{
    public class GioHangReq
    {
        public int IdGioHang { get; set; }
        public int IdSanPham { get; set; }
        public int IdUsers { get; set; }
        public int TrangThai { get; set; }
    }
}
