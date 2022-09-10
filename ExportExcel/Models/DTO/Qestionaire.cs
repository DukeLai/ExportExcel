using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExportExcel.Models.DTO
{
    public class Qestionaire<T>
    {
        public List<T> list { get; set; }
    }

    public class Qestionaire
    {
        public string BarCodeStr { get; set; }
        public string QuestionNo { get; set; }
        public string Category { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TitleNo { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Title { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]

        public string SelectTitle { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)] 
        public string Answer { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Other { get; set; }
    }
}