using System;
using System.Collections.Generic;
using System.Text;

using Shopeee.Common.Rsp;
using Shopeee.Common.BLL;
using Shopeee.DAL;
using Shopeee.DAL.Models;

namespace Shopeee.BLL
{
    public class LoaiSanPhamSvc : GenericSvc<LoaiSanPhamRep, LoaiSanPham>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }
        public override SingleRsp Update(LoaiSanPham m)
        {
            var res = new SingleRsp();

            var m1 = m.IdLoai > 0 ? _rep.Read(m.IdLoai) : _rep.Read(m.TenLoai);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }
    }
}
