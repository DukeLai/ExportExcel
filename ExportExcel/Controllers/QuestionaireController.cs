using ExportExcel.Models.DTO;
using ExportExcel.Security;
using ExportExcel.Services.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExportExcel.Controllers
{
    public class QuestionaireController : Controller
    {
        [JwtAuthActionFilter]
        [HttpPost]
        public ActionResult Update(List<CheckProjectDetail> list)
        {
            string EX = "";
            DataTable dt = new DataTable("MyTable");
            dt = ConvertToDataTable(list);


            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Examine"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("CREATE TABLE  #TmpTable([BarCodeStr] nvarchar(12),[ItemNo]  nvarchar(12),[Value]  nvarchar(500))", conn))
                {
                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();

                        using (SqlBulkCopy bulkcopy = new SqlBulkCopy(conn))
                        {
                            bulkcopy.BulkCopyTimeout = 6600;
                            bulkcopy.DestinationTableName = "#TmpTable";
                            bulkcopy.WriteToServer(dt);
                            bulkcopy.Close();
                        }


                        command.CommandTimeout = 3000;
                        //command.CommandText = "UPDATE P SET P.[Value]= P.[Value] + CHAR(10) + T.[Value] FROM CheckProjectDetail AS P INNER JOIN #TmpTable AS T ON P.[BarCodeStr] = T.[BarCodeStr] and P.[ItemNo] = T.[ItemNo] ;DROP TABLE #TmpTable;";

                        command.CommandText = "MERGE INTO CheckProjectDetail Ｄ USING #TmpTable T ON T.[BarCodeStr]=D.[BarCodeStr] and T.[ItemNo]=D.[ItemNo] WHEN MATCHED THEN   UPDATE SET D.[Value] =  T.[Value] WHEN NOT MATCHED BY TARGET THEN INSERT( [BarCodeStr],[ItemNo] ,[Value] ,[Err] ,[ReadFlag] ,[Source] ,[HandlerID]) VALUES([BarCodeStr],[ItemNo] ,[Value] ,'0','0','Question','Question') ; DROP TABLE #TmpTable;";
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        EX = ex.ToString();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }




            var qry = new { Total = 1, rows = dt ,error=EX };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));
        }
        [JwtAuthActionFilter]
        [HttpPost]
        public ActionResult Insert(List<Qestionaire> list)
        {
            string EX = "";
            DataTable dt = new DataTable("MyTable");
            dt = ConvertToDataTable(list);


            #region SqlBulkCopy開始
            using (SqlBulkCopy sqlBulk = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["Examine"].ConnectionString))
            {
                sqlBulk.DestinationTableName = "CheckProjectQuestion";

                //Mappings setting
                sqlBulk.ColumnMappings.Add("BarCodeStr", "BarCodeStr");
                sqlBulk.ColumnMappings.Add("QuestionNo", "QuestionNo");
                sqlBulk.ColumnMappings.Add("Category", "Category");
                sqlBulk.ColumnMappings.Add("TitleNo", "TitleNo");
                sqlBulk.ColumnMappings.Add("Title", "Title");
                sqlBulk.ColumnMappings.Add("SelectTitle", "SelectTitle");
                sqlBulk.ColumnMappings.Add("Answer", "Answer");
                sqlBulk.ColumnMappings.Add("Other", "Other");

                try
                {
                    sqlBulk.WriteToServer(dt);
                }
                catch (Exception ex)
                {
                    //throw new Exception(ex.Message);
                    //ViewBag.Error = "0," + ex.Message;
                    return Content(JsonConvert.SerializeObject(new { TotalRecord = 0, ErrorMessage = "0" + ex.Message }, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd HH:mm" }));

                }
            }
            #endregion

            var qry = new { Total = 1, rows = dt, error = EX };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));



        }
        [HttpPost]
        public ActionResult Upload(ImportPdfs importPdf)
        {

            string path = Server.MapPath("~/Upload/" + importPdf.files.First().FileName);
            bool exists = System.IO.Directory.Exists(Server.MapPath("~/Upload/"));

            if (!exists)
                System.IO.Directory.CreateDirectory(Server.MapPath("~/Upload/"));

            importPdf.files.First().SaveAs(path);

            var qry = new { Total = 1 };
            return Content(JsonConvert.SerializeObject(qry, new IsoDateTimeConverter() { DateTimeFormat = "yyyy/MM/dd" }));
        }

        // GET: Questionaire
        public ActionResult Index()
        {
            return View();
        }
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}