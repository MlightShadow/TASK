using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskWeb.Models
{
    public class JRes
    {
        /// <summary>
        /// 返回值1 成功 -1 失败
        /// </summary>
        public int res { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string msg { get; set; }
    }

    public class PanelDto
    {
        public string No { get; set; }
        public string name { get; set; }
        public string standard { get; set; }
        public string orderNum { get; set; }
        public string unit { get; set; }
        public string countInput { get; set; }
        public string currentInput { get; set; }
    }
}