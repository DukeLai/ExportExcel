using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    public class MatchController : Controller
    {
        #region 連接資料特性
        private IMatchRepository _repository = null;
        public IMatchRepository Repository
        {
            get
            {
                if (this._repository == null)
                {
                    this._repository = new MatchRepository();
                }
                return this._repository;
            }
        }
        #endregion
        [HttpPost]
        public ActionResult MatchQuery(ReceiveDTO<Login> c)
        {


            Login user = new Login();
            
            ResultDTO result = Repository.GetData(c.parameter);
            user = c.parameter;
            Dictionary<string, FileInfo[]> dic = new Dictionary<string, FileInfo[]>();
            //user.CheckDate = c.parameter.CheckDate;

            try
            {
                foreach (string fname in System.IO.Directory.GetFileSystemEntries(@"\\192.168.25.20\images\" + user.yyyym + @"\" + user.mmdd))
                {
                    //myList.Add(fname);

                    DirectoryInfo d = new DirectoryInfo(fname); //Assuming Test is your Folder

                    FileInfo[] Files = d.GetFiles("*.jpg", SearchOption.AllDirectories); //Getting Text files
                    dic.Add(d.Name.Substring(0, d.Name.IndexOf("_") < 0 ? d.Name.Length : d.Name.IndexOf("_")), Files);
                }
            }
            catch (Exception)
            {

                //throw;
            }



       
            var qry = new { TotalRecord = 0, rows = result.dtResult, file= dic };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));

        }

        [HttpPost]
        public ActionResult MatchQueryTable(ReceiveDTO<Login> c)
        {


            Login user = new Login();

            ResultDTO result = Repository.GetData(c.parameter);

            var qry = new { TotalRecord = result.TotalRecord, rows = result.dtResult };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));

        }
        [HttpPost]
        public ActionResult QueryBarcode(ReceiveDTO<Login> c)
        {
            Login user = new Login();
            ResultDTO result = Repository.GetBarcode(c.parameter);
            var qry = new { TotalRecord = result.TotalRecord, rows = result.dtResult };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));

        }

        [HttpPost]
        public ActionResult MatchQueryFile(ReceiveDTO<Login> c)
        {
            Login user = new Login();
            user = c.parameter;
            Dictionary<string, FileInfo[]> dic = new Dictionary<string, FileInfo[]>();
            //user.CheckDate = c.parameter.CheckDate;

            try
            {
                foreach (string fname in System.IO.Directory.GetFileSystemEntries(@"\\192.168.25.20\images\" + user.yyyym + @"\" + user.mmdd))
                {
                    //myList.Add(fname);

                    DirectoryInfo d = new DirectoryInfo(fname); //Assuming Test is your Folder

                    FileInfo[] Files = d.GetFiles("*.jpg", SearchOption.AllDirectories); //Getting Text files
                    dic.Add(d.Name.Substring(0, d.Name.IndexOf("_") < 0 ? d.Name.Length : d.Name.IndexOf("_")), Files);
                }
            }
            catch (Exception)
            {

                //throw;
            }
            var qry = new { TotalRecord = dic.Count, file = dic };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));

        }


        [HttpPost]
        public ActionResult UPDATE(ReceiveDTO<Login> c)
        {


            ResultDTO result = Repository.Update(c.parameter);

            var qry = new { TotalRecord = result.TotalRecord, rows = result.dtResult };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));

        }
        [HttpPost]
        public ActionResult GetItem(ReceiveDTO<Login> c)
        {
            Login user = new Login();
            ResultDTO result = Repository.GetItem(c.parameter);
            var qry = new { TotalRecord = result.TotalRecord, rows = result.dtResult };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));

        }

        [HttpPost]
        public ActionResult GetGaugeData(ReceiveDTO<Login> c)
        {
            Login user = new Login();
            ResultDTO result = Repository.GetGaugeData(c.parameter);
            var qry = new { TotalRecord = result.TotalRecord, rows = result.dtResult };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));

        }

        // GET: Match
        public ActionResult Index()
        {
            return View();
        }
    }
}