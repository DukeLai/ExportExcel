using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExportExcel.Models;
using ExportExcel.Models.DTO;


namespace ExportExcel.Services.Interface
{
    public interface ICheckProjectRepository
    {
        ResultDTO GetData(CheckProject c);

        ResultDTO Update(string a,CheckProject c);

        ResultDTO GetLiveData(CheckProject c);

    }
}
