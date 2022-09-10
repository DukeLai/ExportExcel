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
    public class CheckProjectController : Controller
    {
        #region 連接資料特性
        private ICheckProjectRepository _repository = null;
        public ICheckProjectRepository Repository
        {
            get
            {
                if (this._repository == null)
                {
                    this._repository = new CheckProjectRepository();
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
            var qry = new { TotalRecord = result.TotalRecord, rows = result.dtResult };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));
        }
        [HttpPost]
        public ActionResult Update66(ReceiveDTO<CheckProject> c)
        {
            CheckProject user = new CheckProject();
            ResultDTO result = Repository.Update(c.Action,c.parameter);
            var qry = new { TotalRecord = result.TotalRecord, rows = result.dtResult };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));
        }
        [HttpPost]
        public ActionResult GetLiveData(ReceiveDTO<CheckProject> c)
        {
            CheckProject user = new CheckProject();
            ResultDTO result = Repository.GetLiveData(c.parameter);
            var qry = new { TotalRecord = result.TotalRecord, rows = result.dtResult };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));
        }

    }
}