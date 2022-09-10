using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExportExcel.Models;
using ExportExcel.Models.DTO;
using ExportExcel.Services.Interface;
using System.Configuration;
using System.Data;
using System.Collections;

namespace ExportExcel.Services.Repository
{
    public class NopaperRepository:INopaperRepository
    {
        MsSQLDBUtility oDS = new MsSQLDBUtility(ConfigurationManager.ConnectionStrings["Examine"].ToString());
        public Login myType = new Login();  //使用Barcode

        public ResultDTO GetData(Login c)
        {
            ResultDTO result = new ResultDTO();
            ArrayList alParameters = new ArrayList();


            alParameters.Add(new object[3] { "@name", SqlDbType.NVarChar, c.UserName });
            alParameters.Add(new object[3] { "@id", SqlDbType.NVarChar, c.PersonalId });
            DataSet ds = oDS.ExecProcedureDataSet(SPName.prc_sp_query_Nopaper, alParameters);

            result.dsResult = ds;
            result.dtResult = ds.Tables[0];

            result.TotalRecord = ds.Tables[0].Rows.Count;


            return result;
        }

        public ResultDTO Update(Login c)
        {
            ResultDTO result = new ResultDTO();
            ArrayList alParameters = new ArrayList();


            alParameters.Add(new object[3] { "@Action", SqlDbType.NVarChar, "UPDATE" });
            alParameters.Add(new object[3] { "@BarcodeStr", SqlDbType.NVarChar, c.BarCodeStr });
            alParameters.Add(new object[3] { "@customerName", SqlDbType.NVarChar, c.UserName });
            alParameters.Add(new object[3] { "@email", SqlDbType.NVarChar, c.Email });
            alParameters.Add(new object[3] { "@IdNo", SqlDbType.NVarChar, c.PersonalId });
            alParameters.Add(new object[3] { "@ErrMsg", SqlDbType.VarChar, "OUTPUT" });

            DataSet ds = oDS.ExecProcedureDataSet(SPName.prc_sp_Update_Nopaper, alParameters);

            result.dsResult = ds;
            result.dtResult = ds.Tables[0];

            string output = ds.Tables[0].Rows[0]["ErrMsg"].ToString();

            result.TotalRecord = int.Parse(output);


            return result;
        }
    }
}