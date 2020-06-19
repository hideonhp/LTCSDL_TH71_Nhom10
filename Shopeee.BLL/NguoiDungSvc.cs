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
    public class NguoiDungSvc : GenericSvc<NguoiDungRep, NguoiDung>
    {
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }
        public object SearchNguoiDung(string keywordus, int pageus, int sizeus)
        {
            var pro = All.Where(x => x.HoVaTen.Contains(keywordus));
            var offset = (pageus - 1) * sizeus;
            var total = pro.Count();
            int totalPages = (total % sizeus) == 0 ? (int)(total / sizeus) : (int)((total / sizeus) + 1);
            var data = pro.OrderBy(x => x.HoVaTen).Skip(offset).Take(sizeus).ToList();

            var res = new
            {
                Data = data,
                TotalRecord = total,
                TotalPages = totalPages,
                PageUs = pageus,
                SizeUs = sizeus
            };
            return res;
        }

        public SingleRsp CreateNguoiDung(NguoiDungReq us)
        {
            var res = new SingleRsp();
            NguoiDung nguoiDung = new NguoiDung();
            nguoiDung.IdUser = us.IdUser;
            nguoiDung.IdTypeUser = us.IdTypeUser;
            nguoiDung.TenDangNhap = us.TenDangNhap;
            nguoiDung.MatKhau = us.MatKhau;
            nguoiDung.HoVaTen = us.HoVaTen;
            nguoiDung.SoDienThoai = us.SoDienThoai;
            nguoiDung.DiaChi = us.DiaChi;
            res = _rep.CreateNguoiDung(nguoiDung);
            return res;
        }
        public SingleRsp UpdateNguoiDung(NguoiDungReq us)
        {
            var res = new SingleRsp();
            NguoiDung nguoiDung = new NguoiDung();
            nguoiDung.IdUser = us.IdUser;
            nguoiDung.IdTypeUser = us.IdTypeUser;
            nguoiDung.TenDangNhap = us.TenDangNhap;
            nguoiDung.MatKhau = us.MatKhau;
            nguoiDung.HoVaTen = us.HoVaTen;
            nguoiDung.SoDienThoai = us.SoDienThoai;
            nguoiDung.DiaChi = us.DiaChi;
            res = _rep.UpdateNguoiDung(nguoiDung);
            return res;
        }
        public object NguoiDung_Insert(int idTypeUser, string tenDangNhap,
            string matKhau, string hoVaTen, string soDienThoai, string diaChi)
        {
            return _rep.NguoiDung_Insert(idTypeUser, tenDangNhap, matKhau, hoVaTen, soDienThoai, diaChi);
        }
        public object NguoiDung_Update(int IdUser, int idTypeUser, string tenDangNhap,
            string matKhau, string hoVaTen, string soDienThoai, string diaChi)
        {
            return _rep.NguoiDung_Update(IdUser , idTypeUser, tenDangNhap, matKhau, hoVaTen, soDienThoai, diaChi);
        }
        public object NguoiDung_DangNhap_Select(string tenDangNhap, string matKhau)
        {
            return _rep.NguoiDung_DangNhap_Select(tenDangNhap, matKhau);
        }
        public object NguoiDung_DangNhap_Admin_Select(string tenDangNhap, string matKhau)
        {
            return _rep.NguoiDung_DangNhap_Admin_Select(tenDangNhap, matKhau);
        }
        public object NguoiDung_Delete(int IdUser)
        {
            return _rep.NguoiDung_Delete(IdUser);
        }

        
    }
}
