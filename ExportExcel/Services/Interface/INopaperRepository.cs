using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExportExcel.Models;
using ExportExcel.Models.DTO;

namespace ExportExcel.Services.Interface
{
    public interface INopaperRepository
    {
        //查詢全部、審核、反審核、審核、反審核、刪除、反刪除

        ResultDTO GetData(Login c);
        //更新
        ResultDTO Update(Login c);


    }
}
