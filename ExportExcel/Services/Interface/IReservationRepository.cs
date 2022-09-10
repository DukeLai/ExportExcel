using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExportExcel.Models;
using ExportExcel.Models.DTO;


namespace ExportExcel.Services.Interface
{
    public interface IReservationRepository
    {
        //查詢全部、審核、反審核、審核、反審核、刪除、反刪除
        ResultDTO GetData(Reservation c);
        //資料匯出
        ResultDTO Export(Reservation c); 
        ResultDTO GetWeeklyData(Reservation c); 
    }
}
