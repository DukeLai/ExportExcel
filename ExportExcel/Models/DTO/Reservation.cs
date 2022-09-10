using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExportExcel.Models.DTO
{
    public class Reservation
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string Amt { get; set; }
        public string desp2 { get; set; }
        public string Name { get; set; }
        public string customerNmae { get; set; }
        public string PremiumCharge { get; set; }
        public string RemitCharge { get; set; }
        public string orderDate { get; set; }


    }
}