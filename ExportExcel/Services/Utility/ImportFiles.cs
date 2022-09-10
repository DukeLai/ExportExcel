using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace ExportExcel.Services.Utility
{
    public class ImportFiles
    {
    }
    public class ImportPdfs
    {
        [Required(ErrorMessage = "Please select file")]
        //[FileExt(Allow = ".pdf", ErrorMessage = "Only PDF file")]
        public IEnumerable<HttpPostedFileBase> files { get; set; }


        //public string year { get; set; }
    }
    public class FileExt : ValidationAttribute
    {
        public string Allow;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool isSuccess = false;
            foreach (var temp in (IEnumerable<HttpPostedFileBase>)value)
            {
                if (temp != null)
                {
                    string extension = Path.GetExtension(((System.Web.HttpPostedFileBase)temp).FileName);
                    if (Allow.Contains(extension))
                    {
                        isSuccess = true;
                    }
                    else
                    {
                        isSuccess = false;
                        break;
                    }
                }
                else
                    isSuccess = true;
            }

            if (isSuccess == true)
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);

        }
    }


}