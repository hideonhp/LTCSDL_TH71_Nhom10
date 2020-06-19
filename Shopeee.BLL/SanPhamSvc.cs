using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shopeee.Common.BLL;
using Shopeee.Common.Req;
using Shopeee.Common.Rsp;
using Shopeee.DAL;
using Shopeee.DAL.Models;

namespace Shopeee.BLL
{
    public class SanPhamSvc : GenericSvc<SanPhamRep, SanPham>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }
        public object  SearchProduct(string keyword, int page, int size)
        {
            var pro = All.Where(x => x.Ten.Contains(keyword));
            var offset = (page - 1) * size;
            var total = pro.Count();
            int totalPages = (total % size) == 0 ? (int)(total / size) : (int)((total / size) + 1);
            var data = pro.OrderBy(x => x.Ten).Skip(offset).Take(size).ToList();

            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPages = totalPages,
                Page = page,
                Size = size
            };
            return res;
        }

        public SingleRsp CreateProduct(ProductsReq pro)
        {
            var res = new SingleRsp();
            SanPham products = new SanPham();
            products.IdSanPham = pro.IdSanPham;
            products.IdLoai = pro.IdLoai;
            products.Ten = pro.Ten;
            products.MoTa = pro.MoTa;
            products.Gia = pro.Gia;
            res = _rep.CreateProduct(products);
            return res;
        }
        public SingleRsp UpdateProduct(ProductsReq pro)
        {
            var res = new SingleRsp();
            SanPham products = new SanPham();
            products.IdSanPham = pro.IdSanPham;
            products.IdLoai = pro.IdLoai;
            products.Ten = pro.Ten;
            products.MoTa = pro.MoTa;
            products.Gia = pro.Gia;
            res = _rep.UpdateProduct(products);
            return res;
        }
        public object SanPham_Select_by_Id(int idLoai)
        {
            return _rep.SanPham_Select_by_Id(idLoai);
        }

    }
}
