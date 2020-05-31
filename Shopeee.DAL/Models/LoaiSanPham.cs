using System;
using System.Collections.Generic;

namespace Shopeee.DAL.Models
{
    public partial class LoaiSanPham
    {
        public LoaiSanPham()
        {
            SanPham = new HashSet<Products>();
        }

        public int IdLoai { get; set; }
        public string TenLoai { get; set; }

        public virtual ICollection<Products> SanPham { get; set; }
    }
}
