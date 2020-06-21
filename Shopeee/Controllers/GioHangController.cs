using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopeee.Common.Req;
using Shopeee.Common.Rsp;
using Shopeee.BLL;

namespace Shopeee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangController : ControllerBase
    {
        private readonly GioHangSvc _svc;
        [HttpPost("gioHang_Insert")]
        public IActionResult SanPham_Select_by_Id([FromBody]GioHangReq req)
        {
            var res = new SingleRsp();
            res.Data = _svc.GioHang_Insert(req.IdSanPham, req.IdUsers );
            return Ok(res);
        }
    }
}