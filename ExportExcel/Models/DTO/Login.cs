using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExportExcel.Models.DTO
{
    public class Login
    {
        public string BarCodeStr { get; set; }
        public string QuestionNo { get; set; }
        public string PersonalId { get; set; }
        public string BirthDate { get; set; }
        public string UserName { get; set; }
        public string CustName { get; set; }
        public string Email { get; set; }

        public string CheckDate { get; set; }
        public string yyyym { get; set; }
        public string mmdd { get; set; }

        public string pic { get; set; }
        public string pic_alt { get; set; }

        public string qc_id { get; set; }



    }
}