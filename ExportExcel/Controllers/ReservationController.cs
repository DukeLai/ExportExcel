using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExportExcel.Models;
using ExportExcel.Models.DTO;
using ExportExcel.Services;
using ExportExcel.Services.Interface;
using ExportExcel.Services.Repository;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using NPOI.SS.UserModel;

namespace ExportExcel.Controllers
{
    public class ReservationController : Controller
    {

        #region 連接資料特性
        private IReservationRepository _repository = null;
        public IReservationRepository Repository
        {
            get
            {
                if (this._repository == null)
                {
                    this._repository = new ReservationRepository();
                }
                return this._repository;
            }
        }
        #endregion
        [HttpPost]
        public ActionResult GetData(ReceiveDTO<Reservation> c)
        {
            ResultDTO result = Repository.GetData(c.parameter);
            var qry = new { Total = result.TotalRecord, rows = result.dtResult };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));
        }
        [HttpPost]
        public ActionResult GetWeeklyData(ReceiveDTO<Reservation> c)
        {
            ResultDTO result = Repository.GetWeeklyData(c.parameter);
            var qry = new { TotalRecord = result.TotalRecord, rows = result.dtResult };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));
        }

        [HttpPost]
        public ActionResult ExportExcel(ReceiveDTO<Reservation> c)
        {
            ResultDTO result = Repository.GetData(c.parameter);
            byte[] fileContents = null;
            //var excelDatas = new MemoryStream();
            IWorkbook workbook = DataTableToExcel.SaveDataSetAsExcel(result.dtResult);
            //workbook.Write(excelDatas);
            //excelDatas.Dispose();
            string fullPath = Path.Combine(Server.MapPath("~/Reports"), "學生資料.xlsx");
            //excelDatas.Position = 0;
            string temppath = Server.MapPath("~/TempFile");
            bool exists = System.IO.Directory.Exists(temppath);

            if (!exists)
                System.IO.Directory.CreateDirectory(temppath);
            using (var memoryStream = new MemoryStream())
            {
                workbook.Write(memoryStream);
                fileContents = memoryStream.ToArray();
            }
            var tempfileName = "excelfile" + new Guid().ToString() + ".xlsx";

            FileStream tempstream = new FileStream(Path.Combine(temppath, tempfileName), FileMode.Create, FileAccess.Write);
            workbook.Write(tempstream);
            tempstream.Close();
           
            return Json(tempfileName, JsonRequestBehavior.AllowGet);
            //return File(fileContents, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fullPath);

            
        }
        public ActionResult download(string tempfileName)
        {
            string temppath = Server.MapPath("~/TempFile");
            string filePath = Path.Combine(temppath, tempfileName);
            var downloadfile = File(filePath, "application/vnd.ms-excel", tempfileName);
            return downloadfile;
        }

        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }
    }
}