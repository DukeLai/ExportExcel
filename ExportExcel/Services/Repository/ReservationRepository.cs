using ExportExcel.Models;
using ExportExcel.Models.DTO;
using ExportExcel.Services.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace ExportExcel.Services.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        MsSQLDBUtility oDS = new MsSQLDBUtility(ConfigurationManager.ConnectionStrings["Examine"].ToString());
        public Reservation myType = new Reservation();


        public ResultDTO GetData(Reservation c)
        {
            ResultDTO result = new ResultDTO();
            ArrayList alParameters = new ArrayList();


            alParameters.Add(new object[3] { "@startDate", SqlDbType.VarChar, c.startDate.Replace("-","/") });
            alParameters.Add(new object[3] { "@endDate", SqlDbType.VarChar, c.endDate.Replace("-", "/") });
            DataSet ds = oDS.ExecProcedureDataSet(SPName.prc_sp_query_ReservationForAestheticMedicine, alParameters);

            result.dsResult = ds;
            result.dtResult = ds.Tables[0];

            return result;
        }
        public ResultDTO GetWeeklyData(Reservation c)
        {
            ResultDTO result = new ResultDTO();
            ArrayList alParameters = new ArrayList();


            alParameters.Add(new object[3] { "@startDate", SqlDbType.VarChar, c.startDate });
            alParameters.Add(new object[3] { "@endDate", SqlDbType.VarChar, c.endDate });
            DataSet ds = oDS.ExecProcedureDataSet(SPName.prc_sp_query_WeeklyReservationSummation, alParameters);

            result.dsResult = ds;
            result.dtResult = ds.Tables[0];

            result.TotalRecord = ds.Tables[0].Rows.Count;


            return result;
        }

        public ResultDTO Export(Reservation c)
        {
            throw new NotImplementedException();
        }
    }
}