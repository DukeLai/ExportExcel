﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExportExcel.Models;
using ExportExcel.Models.DTO;



namespace ExportExcel.Services.Interface
{
    public interface ILabourCheckRepository
    {
        ResultDTO GetData(Login c);

    }
}
