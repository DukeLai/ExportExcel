using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExportExcel.Models.DTO
{
    public class PersonItem
    {
        public string AutoInc { get; set; }
        public string BarCodeStr { get; set; }

        //傳遞
        public string Type { get; set; }
        public string SchemeNo { get; set; }

        public string CategoryNo { get; set; }
        public string ItemNo { get; set; }
        public string OtherItems { get; set; }
        public string PersonPrice { get; set; }
        public string DecItems { get; set; }
        

    }
}