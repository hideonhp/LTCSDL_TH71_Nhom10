using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shopeee.Web.Controllers
{
    using BLL;
    using DAL.Models;
    using Common.Req;
    using Common.Rsp;

    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSanPhamController : ControllerBase
    {
        public LoaiSanPhamController()
        {
            _svc = new LoaiSanPhamSvc();
        }

        [HttpPost("get-by-id")]
        public IActionResult getLoaiSanPhamById([FromBody]SimpleReq req)
        {
            var res = new SingleRsp();
            res = _svc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("get-all")]
        public IActionResult getAllLoaiSanPhamById()
        {
            var res = new SingleRsp();
            res.Data = _svc.All;
            return Ok(res);
        }


        private readonly LoaiSanPhamSvc _svc;
    }
}