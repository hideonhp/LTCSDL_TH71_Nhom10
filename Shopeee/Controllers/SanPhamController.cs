﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Shopeee.BLL;
using Shopeee.Common.Req;
using Shopeee.Common.Rsp;

namespace Shopeee.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        public SanPhamController()
        {
            _svc = new SanPhamSvc();
        }
        [HttpPost("tim-kiem-san-pham")]
        public IActionResult SearchProduct([FromBody]SearchProductReq req)
        {
            var res = new SingleRsp();
            var pros = _svc.SearchProduct(req.KeyWord, req.Page, req.Size);
            res.Data = pros;
            return Ok(res);
        }
        private readonly SanPhamSvc _svc;
        
        [HttpPost("tao-san-pham")]
        public IActionResult CreateProduct([FromBody]ProductsReq req)
        {
            var pros = _svc.CreateProduct(req);
            return Ok(req);
        }
        [HttpPost("cap-nhap-san-pham")]
        public IActionResult UpdateProduct([FromBody]ProductsReq req)
        {
            var pros = _svc.UpdateProduct(req);
            return Ok(req);
        }
    }
}