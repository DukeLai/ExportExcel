using Jose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ExportExcel.Security
{
    public class JwtAuthActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            // TODO: key應該移至config
            string secret = "@myJwtAuthDemo";//加解密的key,如果不一樣會無法成功解密

            //取得回傳的header資料裡面的token字段的值
            var headers = actionContext.HttpContext.Request.Headers;
            string token = headers["token"];

            if (token != null)
            {
                try
                {
                    //解密後會回傳Json格式的物件(即加密前的資料)
                    var jwtObject = Jose.JWT.Decode<Dictionary<string, Object>>(
                    token.Replace(@"""", ""),
                    Encoding.UTF8.GetBytes(secret),
                    JwsAlgorithm.HS512);
                    //內部驗證
                    if (IsTokenCheck(jwtObject["InnerCkeck"].ToString()))
                    {
                        //內部驗證通過，則解析Account訊息，方便給後端查詢
                        actionContext.Controller.ViewData.Add("BarCodeStr", jwtObject["BarCodeStr"]);
                        actionContext.Controller.ViewData.Add("AccountID", jwtObject["AccountID"]);
                        //return Content(JsonConvert.SerializeObject("Not Allowed", new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd HH:mm" }));
                    }
                    else
                    {
                        //若是不通過，則顯示錯誤訊息"Not Allowed"給前端
                        actionContext.HttpContext.Response.Write("Not Allowed");
                        throw new UnauthorizedAccessException("帳號密碼錯誤");
                    }
                    //時效驗證
                    //if (IsTokenExpired(jwtObject["Exp"].ToString()))
                    //{
                    //    throw new System.Exception("Token Expired");
                    //}
                    //string all = "";
                }
                catch (Exception ex)
                {
                    //若是不通過，則顯示錯誤訊息"Not Allowed"給前端
                    actionContext.HttpContext.Response.Write("Not Allowed");
                    throw new UnauthorizedAccessException("帳號密碼錯誤");

                    //throw new System.Exception(ex.ToString());

                    //setErrorResponse(actionContext, ex.Message);
                }

            }
            else
            {
                //若是不通過，則顯示錯誤訊息"Not Allowed"給前端
                //throw new { "驗證錯誤" };
                actionContext.HttpContext.Response.Write("Not Allowed");
                throw new UnauthorizedAccessException("帳號密碼錯誤");

                //throw new System.Exception("驗證錯誤");
            }

            base.OnActionExecuting(actionContext);
        }

        //private static void setErrorResponse(ActionExecutingContext actionContext, string message)
        //{
        //    var response = actionContext.HttpContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, message);
        //    actionContext.HttpContext.Response = response;
        //}

        //驗證token時效
        public bool IsTokenExpired(string dateTime)
        {
            return Convert.ToDateTime(dateTime) < DateTime.Now;
        }
        public bool IsTokenCheck(string checkString)
        {
            //自創檢查字段
            return checkString == "Influence";
        }


    }
}