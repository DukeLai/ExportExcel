using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExportExcel.Models.DTO
{
    public class Home
    {
        //LINE參數
        public string code { get; set; }
        public string state { get; set; }

        //傳遞
        public string token { get; set; }
        public string messages { get; set; }

    }
}