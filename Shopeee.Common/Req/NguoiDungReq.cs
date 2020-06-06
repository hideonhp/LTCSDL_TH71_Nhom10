using System;
using System.Collections.Generic;
using System.Text;

namespace Shopeee.Common.Req
{
    public class NguoiDungReq
    {
        public int IdUser { get; set; }
        public int IdTypeUser { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string HoVaTen { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
    }
}
