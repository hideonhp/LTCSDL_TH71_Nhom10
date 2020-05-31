using System;
using System.Collections.Generic;
using System.Text;
using Shopeee.Common.DAl;
using System.Linq;

namespace Shopeee.DAL
{
    using Shopeee.DAL.Models;
    public class LoaiSanPhamRep : GenericRep<SteveJobsContext, LoaiSanPham>
    {
        #region -- Overrides --
        public override LoaiSanPham Read(int id)
        {
            var res = All.FirstOrDefault(p => p.IdLoai == id);
            return res;
        }
        public int Remove(int id)
        {
            var m = base.All.First(i => i.IdLoai == id);
            m = base.Delete(m);
            return m.IdLoai;
        }

        #endregion
    }
}
