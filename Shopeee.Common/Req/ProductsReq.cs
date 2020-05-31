using System;
using System.Collections.Generic;
using System.Text;

namespace Shopeee.Common.Req
{
    public class ProductsReq
    {
        public int IdSanPham { get; set; }
        public int IdLoai { get; set; }
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public string Gia { get; set; }
    }
}
