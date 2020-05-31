using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class DonHang
    {
        public DonHang()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        public int IdDonHang { get; set; }
        public int IdUser { get; set; }
        public DateTime NgayDat { get; set; }
        public string TongTien { get; set; }
        public string TinhTrangDonHang { get; set; }

        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }
    }
}
