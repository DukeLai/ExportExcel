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
    public class CheckProjectNameListRepository : ICheckProjectNameListRepository
    {
        MsSQLDBUtility oDS = new MsSQLDBUtility(ConfigurationManager.ConnectionStrings["Examine"].ToString());
        public CheckProject myType = new CheckProject();

        public ResultDTO GetData(CheckProjectNameList c)
        {
            ResultDTO result = new ResultDTO();
            ArrayList alParameters = new ArrayList();


            alParameters.Add(new object[3] { "@QueryString", SqlDbType.NVarChar, c.QueryString });
            DataSet ds = oDS.ExecProcedureDataSet(SPName.prc_sp_query_PersonCustomer, alParameters);

            result.dsResult = ds;
            result.dtResult = ds.Tables[0];
            result.TotalRecord = ds.Tables[0].Rows.Count;


            return result;
        }

    }
}