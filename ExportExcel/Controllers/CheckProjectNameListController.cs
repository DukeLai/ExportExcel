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
    public class CheckProjectNameListController : Controller
    {
        #region 連接資料特性
        private ICheckProjectNameListRepository _repository = null;
        public ICheckProjectNameListRepository Repository
        {
            get
            {
                if (this._repository == null)
                {
                    this._repository = new CheckProjectNameListRepository();
                }
                return this._repository;
            }
        }
        #endregion

        // GET: CheckProject
        [HttpPost]
        public ActionResult GetData(ReceiveDTO<CheckProjectNameList> c)
        {
            CheckProjectNameList user = new CheckProjectNameList();
            ResultDTO result = Repository.GetData(c.parameter);
            var qry = new { TotalRecord = result.TotalRecord, rows = result.dtResult};
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));
        }

    }
}