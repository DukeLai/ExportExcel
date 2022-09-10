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
    public class QrcodeRepository: IQrcodeRepository
    {
        MsSQLDBUtility oDS = new MsSQLDBUtility(ConfigurationManager.ConnectionStrings["Examine"].ToString());
        public Login myType = new Login();  //使用Barcode

        public ResultDTO GetData(Login c)
        {
            ResultDTO result = new ResultDTO();
            ArrayList alParameters = new ArrayList();

            alParameters.Add(new object[3] { "@BarcodeStr", SqlDbType.NVarChar, c.BarCodeStr });

            DataSet ds = oDS.ExecProcedureDataSet(SPName.prc_sp_Update_PreCheck, alParameters);

            result.dsResult = ds;
            result.dtResult = ds.Tables[1];

            result.TotalRecord = ds.Tables[1].Rows.Count;


            return result;


        }
    }
}