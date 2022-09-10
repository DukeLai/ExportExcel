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
    public class RoomBookingRepository : IRoomBookingRepository
    {
        MsSQLDBUtility oDS = new MsSQLDBUtility(ConfigurationManager.ConnectionStrings["Examine"].ToString());
        public RoomBooking myType = new RoomBooking();  //使用Barcode

        public ResultDTO GetData(RoomBooking c)
        {
            ResultDTO result = new ResultDTO();
            ArrayList alParameters = new ArrayList();


            alParameters.Add(new object[3] { "@dateStart", SqlDbType.NVarChar, c.dateStart });
            alParameters.Add(new object[3] { "@dateEnd", SqlDbType.NVarChar, c.dateEnd });
            DataSet ds = oDS.ExecProcedureDataSet(SPName.prc_sp_query_RoomBooking, alParameters);

            result.dsResult = ds;
            result.dtResult = ds.Tables[0];

            result.TotalRecord = ds.Tables[0].Rows.Count;


            return result;
        }

        public ResultDTO Update(ReceiveDTO<RoomBooking> c)
        {
            ResultDTO result = new ResultDTO();
            ArrayList alParameters = new ArrayList();
            myType = c.parameter;

            alParameters.Add(new object[3] { "@Action", SqlDbType.NVarChar, c.Action });
            alParameters.Add(new object[3] { "@roomBookingID", SqlDbType.NVarChar, myType.roomBookingID == null?"": myType.roomBookingID });
            alParameters.Add(new object[3] { "@meetingRoomID", SqlDbType.NVarChar, myType.resourceId == null ? "" : myType.resourceId });
            alParameters.Add(new object[3] { "@title", SqlDbType.NVarChar, myType.title }); 
            alParameters.Add(new object[3] { "@department", SqlDbType.NVarChar, myType.department });
            alParameters.Add(new object[3] { "@start", SqlDbType.NVarChar, myType.start });
            alParameters.Add(new object[3] { "@end", SqlDbType.NVarChar, myType.end });
            alParameters.Add(new object[3] { "@ErrMsg", SqlDbType.VarChar, "OUTPUT" });

            DataSet ds = oDS.ExecProcedureDataSet(SPName.prc_sp_Update_RoomBooking, alParameters);

            result.dsResult = ds;
            result.dtResult = ds.Tables[0];

            string output = ds.Tables[0].Rows[0]["ErrMsg"].ToString();

            result.TotalRecord = int.Parse(output);


            return result;
        }
    }
}