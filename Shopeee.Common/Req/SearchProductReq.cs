using System;
using System.Collections.Generic;
using System.Text;

namespace Shopeee.Common.Req
{
    public class SearchProductReq
    {
        public int Page { get; set; }

        public int Size { get; set; }

        public int Id { get; set; }

        public String Type { get; set; }

        public String KeyWord { get; set; }

    }
}
