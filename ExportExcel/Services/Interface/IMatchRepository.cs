using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExportExcel.Models;
using ExportExcel.Models.DTO;

namespace ExportExcel.Services.Interface
{
    public interface IMatchRepository
    {

        ResultDTO GetData(Login c);
        //更新
        ResultDTO Update(Login c);
        ResultDTO GetBarcode(Login c);
        ResultDTO GetItem(Login c);
        ResultDTO GetGaugeData(Login c);



    }
}
