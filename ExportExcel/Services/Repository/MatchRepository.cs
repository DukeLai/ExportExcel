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
    public class MatchRepository: IMatchRepository
    {
        MsSQLDBUtility oDS = new MsSQLDBUtility(ConfigurationManager.ConnectionStrings["Medirep"].ToString());
        public Login myType = new Login();

        public ResultDTO GetData(Login c)
        {
            ResultDTO result = new ResultDTO();
            ArrayList alParameters = new ArrayList();


            alParameters.Add(new object[3] { "@checkdate", SqlDbType.NVarChar, c.CheckDate });
            DataSet ds = oDS.ExecProcedureDataSet(SPName.prc_sp_query_custome, alParameters);

            result.dsResult = ds;
            result.dtResult = ds.Tables[0];

            result.TotalRecord = ds.Tables[0].Rows.Count;


            return result;
        }
        public ResultDTO GetBarcode(Login c)
        {
            ResultDTO result = new ResultDTO();
            ArrayList alParameters = new ArrayList();


            alParameters.Add(new object[3] { "@qc_id", SqlDbType.NVarChar, c.qc_id });
            DataSet ds = oDS.ExecProcedureDataSet(SPName.prc_sp_query_customeByID, alParameters);

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
            alParameters.Add(new object[3] { "@pic", SqlDbType.NVarChar, c.pic });
            alParameters.Add(new object[3] { "@pic_alt", SqlDbType.NVarChar, c.pic_alt });
            alParameters.Add(new object[3] { "@qc_id", SqlDbType.NVarChar, c.qc_id });
            alParameters.Add(new object[3] { "@ErrMsg", SqlDbType.NVarChar, "OUTPUT" });

            DataSet ds = oDS.ExecProcedureDataSet(SPName.prc_sp_Update_queryCustome_pic, alParameters);

            result.dsResult = ds;
            result.dtResult = ds.Tables[0];


            string output = ds.Tables[0].Rows[0]["ErrMsg"].ToString();

            result.TotalRecord = int.Parse(output);


            return result;
        }

        public ResultDTO GetItem(Login c)
        {
            ResultDTO result = new ResultDTO();
            ArrayList alParameters = new ArrayList();


            DataSet ds = oDS.ExecProcedureDataSet(SPName.prc_sp_query_categories, alParameters);

            result.dsResult = ds;
            result.dtResult = ds.Tables[0];

            result.TotalRecord = ds.Tables[0].Rows.Count;


            return result;
        }

        public ResultDTO GetGaugeData(Login c)
        {
            ResultDTO result = new ResultDTO();
            ArrayList alParameters = new ArrayList();


            alParameters.Add(new object[3] { "@barcode", SqlDbType.NVarChar, c.BarCodeStr });
            DataSet ds = oDS.ExecProcedureDataSet(SPName.prc_sp_query_gauge_data, alParameters);

            result.dsResult = ds;
            result.dtResult = ds.Tables[0];

            result.TotalRecord = ds.Tables[0].Rows.Count;


            return result;
        }
    }
}