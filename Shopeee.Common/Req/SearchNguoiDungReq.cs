using System;
using System.Collections.Generic;
using System.Text;

namespace Shopeee.Common.Req
{
    public class SearchNguoiDungReq
    {
        public int PageUs { get; set; }

        public int SizeUs { get; set; }

        public int IdUs { get; set; }

        public String TypeUs { get; set; }

        public String KeyWordUs { get; set; }
    }
}
