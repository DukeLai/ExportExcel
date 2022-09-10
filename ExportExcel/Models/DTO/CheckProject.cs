using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExportExcel.Models.DTO
{
    public class CheckItem
    {
        public string CheckNo { get; set; }
        public string Name { get; set; }

        //傳遞
        public string PublicExpense { get; set; }
        public string OwnExpense { get; set; }



    }
}