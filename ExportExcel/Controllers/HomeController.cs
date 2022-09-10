using ExportExcel.Models.DTO;
using Hangfire;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ExportExcel.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public async Task<ActionResult> Contact(Home home)
        {
            //var client = httpClientFactory.CreateClient();
            //var result = await client.GetStringAsync("https://run.mocky.io/v3/cfe75614-d760-41fb-8222-03e9596f1f16");

            //HttpRequestMessage message = new HttpRequestMessage();
            //message.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            //message.Headers.Add("Authorization", "zDMxSsO7NHQ2WNDZj7mCl8pAtclz2OZDJqb2tXIiS4k");
            //client.DefaultRequestHeaders.Add("Authorization", "zDMxSsO7NHQ2WNDZj7mCl8pAtclz2OZDJqb2tXIiS4k");
            //message.RequestUri = new Uri("https://notify-api.line.me/api/notify");
            //message.Content = new JsonContent(new { message = "OKOK2" });
            //client.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "zDMxSsO7NHQ2WNDZj7mCl8pAtclz2OZDJqb2tXIiS4k");
            //var result = await client.PostAsync("https://notify-api.line.me/api/notify", new JsonContent(new { message = "OKOK2" }));
            //HttpResponseMessage response = await client.SendAsync(message);
            //var result = await response.Content.ReadAsStringAsync();



            //await PushNotify("zDMxSsO7NHQ2WNDZj7mCl8pAtclz2OZDJqb2tXIiS4k", $"Hi, 金城武 剛剛報名了婚禮，他當天會出席!");

            //return View();

            RecurringJob.AddOrUpdate(() => PushNotify("zDMxSsO7NHQ2WNDZj7mCl8pAtclz2OZDJqb2tXIiS4k", $"Hi, 金城 武 剛剛報名了婚禮，他當天會出席!"), Cron.Minutely);
            
            //await PushNotify(home.token,home.messages);

            return Content("");

        }
        public ActionResult Post(string content)
        {
            // fire and got:站台啟動後只會執行一次
            BackgroundJob.Enqueue(() => Send(content));
            return Content("");
        }

        public static void Send(string message)
        {
            Debug.WriteLine($"由Hangfire發送的訊息:{message}, 時間:{DateTime.Now}");
        }

        public static async Task<string> GetAccessToken(string code)

        {

            using (var httpClient = new HttpClient())

            {

                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://notify-bot.line.me/oauth/token"))

                {

                    var redirect_uri = "https://www.mornjoy.com.tw/exportexcel/home/test";

                    var client_id = "cD6fcMXzLV8GL76u2hL5xB";

                    var client_secret = "XqDonAsQMnFDWXnRvez7JJSoewe2AC1ytWTKF1b6l17";

                    //var code = "XXXXX";

                    request.Content = new StringContent($"grant_type=authorization_code&redirect_uri={redirect_uri}&client_id={client_id}&client_secret={client_secret}&code={code}");

                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);

                    var results = await response.Content.ReadAsStringAsync();

                    return results;

                }

            }

        }
        public async Task<ActionResult> Test(Home home)
        {
 

            if (home.state == "azsx9999")
            {
                var accessToken = await GetAccessToken(home.code);
                return Content(accessToken);
            }
            else
            {
                return Content("連動失敗");

            }

          

            //scope給openid是程式為了抓id_token用，設email則為了id_token的Payload裡才會有用戶的email資訊
        }
        public static async Task PushNotify(string accessToken, string message)

        {

            using (var httpClient = new HttpClient())

            {

                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://notify-api.line.me/api/notify"))

                {

                    request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");

                    request.Content = new StringContent($"message={message}");

                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    var response = await httpClient.SendAsync(request);

                }

            }

        }

    }
    public class JsonContent : StringContent
    {
        public JsonContent(object obj) :
            base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json")
        { }
    }

}