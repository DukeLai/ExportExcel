using ExportExcel.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jose;
using System.Text;

namespace ExportExcel.Security
{
    public class JwtAuthUtil
    {
        public string GenerateToken(Login home)
        {
            string secret = "@myJwtAuthDemo";//加解密的key,如果不一樣會無法成功解密
            Dictionary<string, Object> claim = new Dictionary<string, Object>();//payload 需透過token傳遞的資料
            claim.Add("BarCodeStr", home.BarCodeStr);
            claim.Add("AccountID", home.PersonalId);
            claim.Add("InnerCkeck", "Influence");       //自製的字段之一，會變成token的值
            //claim.Add("Company", "appx");
            //claim.Add("Department", "rd");
            claim.Add("Exp", DateTime.Now.AddSeconds(Convert.ToInt32("30")).ToString());//Token 時效設定100秒，但目前未檢查此項
            var payload = claim;
            var token = Jose.JWT.Encode(payload, Encoding.UTF8.GetBytes(secret), JwsAlgorithm.HS512);//產生token
            return token;
        }

    }
}