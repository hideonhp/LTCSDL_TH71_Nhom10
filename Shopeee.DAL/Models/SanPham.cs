using System;
using System.Collections.Generic;

namespace Shopeee.DAL.Models
{
    public partial class Products
    {
        public Products()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        public int IdSanPham { get; set; }
        public int IdLoai { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public string Gia { get; set; }

        public virtual LoaiSanPham IdLoaiNavigation { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }
    }
}
