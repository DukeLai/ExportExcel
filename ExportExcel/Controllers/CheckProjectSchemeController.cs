using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExportExcel.Models;
using ExportExcel.Models.DTO;
using ExportExcel.Security;
using ExportExcel.Services;
using ExportExcel.Services.Interface;
using ExportExcel.Services.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;



namespace ExportExcel.Controllers
{
    public class CheckProjectSchemeController : Controller
    {
        #region 連接資料特性
        private ICheckProjectSchemeRepository _repository = null;
        public ICheckProjectSchemeRepository Repository
        {
            get
            {
                if (this._repository == null)
                {
                    this._repository = new CheckProjectSchemeRepository();
                }
                return this._repository;
            }
        }
        #endregion

        // GET: CheckProject
        [HttpPost]
        public ActionResult GetData(ReceiveDTO<CheckProject> c)
        {
            CheckProject user = new CheckProject();
            ResultDTO result = Repository.GetData(c.parameter);
            var qry = new { TotalRecord = result.TotalRecord, rows = result.dsResult.Tables[0], rowsGroup=result.dsResult.Tables[1] };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));
        }
    }
}