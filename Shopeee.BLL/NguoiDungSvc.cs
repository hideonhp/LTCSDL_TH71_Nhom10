using System;
using System.Collections.Generic;
using System.Text;
using Shopeee.DAL;
using Shopeee.DAL.Models;
using Shopeee.Common.BLL;

namespace Shopeee.BLL
{
    public class NguoiDungSvc : GenericSvc<NguoiDungRep, NguoiDung>
    {
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
