using BOMProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOMProject.Business.Contracts
{
    public interface IExcelImportService
    {
        ImportResult ImportExcelData(string filePath);
    }
}
