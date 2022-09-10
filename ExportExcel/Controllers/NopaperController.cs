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
    public class NopaperController : Controller
    {
        #region 連接資料特性
        private INopaperRepository _repository = null;
        public INopaperRepository Repository
        {
            get
            {
                if (this._repository == null)
                {
                    this._repository = new NopaperRepository();
                }
                return this._repository;
            }
        }
        #endregion

        // GET: Nopaper
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        // GET: Nopaper
        public ActionResult GetData(ReceiveDTO<Login> c)
        {
            Login user = new Login();
            ResultDTO result = Repository.GetData(c.parameter);
                var qry = new { TotalRecord = result.TotalRecord, rows = result.dtResult };
                return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));


        }
        [HttpPost]
        // GET: Nopaper
        public ActionResult Update(ReceiveDTO<Login> c)
        {
            Login user = new Login();
            ResultDTO result = Repository.Update(c.parameter);
            var qry = new { TotalRecord = result.TotalRecord, rows = result.dtResult };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));


        }
    }
}