using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExportExcel.Models.DTO
{
    public class CheckProject
    {
        public string ProjectNo { get; set; }
        public string ProjectName { get; set; }

        //傳遞
        public string Note { get; set; }
        public string CheckYear { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }


    }
}