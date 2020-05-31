using System;
using System.Collections.Generic;

namespace Shopeee.DAL.Models
{
    public partial class KieuNguoiDung
    {
        public KieuNguoiDung()
        {
            NguoiDung = new HashSet<NguoiDung>();
        }

        public int IdTypeUser { get; set; }
        public string TypeUser { get; set; }

        public virtual ICollection<NguoiDung> NguoiDung { get; set; }
    }
}
