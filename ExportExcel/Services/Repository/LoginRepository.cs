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
    public class LoginRepository:ILoginRepository
    {
        MsSQLDBUtility oDS = new MsSQLDBUtility(ConfigurationManager.ConnectionStrings["Examine"].ToString());
        public Login myType = new Login();

        public ResultDTO GetData(Login c)
        {
            ResultDTO result = new ResultDTO();
            ArrayList alParameters = new ArrayList();


            alParameters.Add(new object[3] { "@UserName", SqlDbType.NVarChar, c.UserName });
            alParameters.Add(new object[3] { "@PersonalId", SqlDbType.NVarChar, c.PersonalId });
            alParameters.Add(new object[3] { "@BirthDate", SqlDbType.NVarChar, c.BirthDate });
            DataSet ds = oDS.ExecProcedureDataSet(SPName.prc_sp_query_QuestionLogin, alParameters);

            result.dsResult = ds;
            result.dtResult = ds.Tables[0];

            result.TotalRecord = ds.Tables[0].Rows.Count;


            return result;
        }
    }
}