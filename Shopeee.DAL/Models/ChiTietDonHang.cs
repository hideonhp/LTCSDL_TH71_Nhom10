using System;
using System.Collections.Generic;

namespace Shopeee.DAL.Models
{
    public partial class ChiTietDonHang
    {
        public int IdSanPham { get; set; }
        public int IdDonHang { get; set; }
        public string SoLuong { get; set; }

        public virtual DonHang IdDonHangNavigation { get; set; }
        public virtual Products IdSanPhamNavigation { get; set; }
    }
}
