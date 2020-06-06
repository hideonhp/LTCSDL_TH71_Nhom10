using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopeee.BLL;
using Shopeee.Common.Req;
using Shopeee.Common.Rsp;

namespace Shopeee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        public NguoiDungController()
        {
            _svc = new NguoiDungSvc();
        }

        private readonly NguoiDungSvc _svc;

        [HttpPost("NguoiDung_Insert")]
        public IActionResult NguoiDung_Insert([FromBody]NguoiDungReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.NguoiDung_Insert(req.IdTypeUser, req.TenDangNhap, req.MatKhau,
                req.HoVaTen, req.SoDienThoai, req.DiaChi);
            return Ok(res);
        }
        [HttpPost("NguoiDung_Delete")]
        public IActionResult NguoiDung_Delete([FromBody]NguoiDungReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.NguoiDung_Delete(req.IdUser);
            return Ok(res);
        }
        [HttpPost("NguoiDung_Update")]
        public IActionResult NguoiDung_Update([FromBody]NguoiDungReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.NguoiDung_Update(req.IdUser, req.IdTypeUser, req.TenDangNhap, req.MatKhau,
                req.HoVaTen, req.SoDienThoai, req.DiaChi);
            return Ok(res);
        }
        [HttpPost("NguoiDung_DangNhap_Select")]
        public IActionResult NguoiDung_DangNhap_Select([FromBody]NguoiDungReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.NguoiDung_DangNhap_Select(req.TenDangNhap, req.MatKhau);
            return Ok(res);
        }
        [HttpPost("NguoiDung_DangNhap_Admin_Select")]
        public IActionResult NguoiDung_DangNhap_Admin_Select([FromBody]NguoiDungReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.NguoiDung_DangNhap_Admin_Select(req.TenDangNhap, req.MatKhau);
            return Ok(res);
        }
    }
}