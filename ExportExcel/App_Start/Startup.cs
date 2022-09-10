using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Hangfire.Dashboard;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;
using System.Web.Hosting;
using System.Diagnostics;
using Hangfire.MemoryStorage;

[assembly: OwinStartup(typeof(ExportExcel.Startup))]
namespace ExportExcel
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 指定Hangfire使用記憶體儲存任務
            GlobalConfiguration.Configuration.UseMemoryStorage();
            // 啟用HanfireServer
            app.UseHangfireServer();
            // 啟用Hangfire的Dashboard
            app.UseHangfireDashboard();
        }
    }

}