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
    public class RoomBookingController : Controller
    {
        #region 連接資料特性
        private IRoomBookingRepository _repository = null;
        public IRoomBookingRepository Repository
        {
            get
            {
                if (this._repository == null)
                {
                    this._repository = new RoomBookingRepository();
                }
                return this._repository;
            }
        }
        #endregion

        // GET: RoomBooking
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        // GET: Nopaper
        public ActionResult GetData(ReceiveDTO<RoomBooking> c)
        {
            //Login user = new Login();
            ResultDTO result = Repository.GetData(c.parameter);
            var qry = new { TotalRecord = result.TotalRecord, rows = result.dtResult };
            return Content(JsonConvert.SerializeObject(qry));


        }
        [HttpPost]
        // GET: Nopaper
        public ActionResult Add(ReceiveDTO<RoomBooking> c)
        {
            Login user = new Login();
            ResultDTO result = Repository.Update(c);
            var qry = new { TotalRecord = result.TotalRecord, rows = result.dtResult };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));
        }
        public ActionResult Update(ReceiveDTO<RoomBooking> c)
        {
            Login user = new Login();
            ResultDTO result = Repository.Update(c);
            var qry = new { TotalRecord = result.TotalRecord, rows = result.dtResult };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));
        }
        public ActionResult Delete(ReceiveDTO<RoomBooking> c)
        {
            Login user = new Login();
            ResultDTO result = Repository.Update(c);
            var qry = new { TotalRecord = result.TotalRecord, rows = result.dtResult };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));
        }

    }
}