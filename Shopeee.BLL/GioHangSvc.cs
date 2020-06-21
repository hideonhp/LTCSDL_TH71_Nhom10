using System;
using System.Collections.Generic;
using System.Text;
using Shopeee.DAL;
using Shopeee.DAL.Models;
using Shopeee.Common.BLL;
using System.Linq;
using Shopeee.Common.Rsp;
using Shopeee.Common.Req;

namespace Shopeee.BLL
{
    public class GioHangSvc : GenericSvc<GioHangRep, GioHang>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }
        public object GioHang_Insert(int idSanPham, int idUser)
        {
            return _rep.GioHang_Insert(idSanPham, idUser);
        }
    }
}
