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
    public class LoginController : Controller
    {
        #region 連接資料特性
        private ILoginRepository _repository = null;
        public ILoginRepository Repository
        {
            get
            {
                if (this._repository == null)
                {
                    this._repository = new LoginRepository();
                }
                return this._repository;
            }
        }
        #endregion
        [HttpPost]
        public ActionResult Check(ReceiveDTO<Login> c)
        {
            Login user = new Login();
            ResultDTO result = Repository.GetData(c.parameter);
            if (result.TotalRecord > 0)
            {
                user.UserName = result.dtResult.Rows[0]["name"].ToString();
                user.PersonalId = result.dtResult.Rows[0]["ID"].ToString();
                user.BarCodeStr = result.dtResult.Rows[0]["BarCodeStr"].ToString();
                user.BirthDate = result.dtResult.Rows[0]["Birthday"].ToString();
                user.Email = result.dtResult.Rows[0]["Email"].ToString();
                user.CustName = result.dtResult.Rows[0]["CustName"].ToString();

                JwtAuthUtil jwtAuthUtil = new JwtAuthUtil();
                string jwtToken = jwtAuthUtil.GenerateToken(user);
                var qry = new { TotalRecord = result.TotalRecord, token = jwtToken, rows = result.dtResult, UserInfo= user };
                return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));


            }
            else
            {
                var qry = new { TotalRecord = result.TotalRecord, rows = result.dtResult };
                return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));
            }
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
    }
}