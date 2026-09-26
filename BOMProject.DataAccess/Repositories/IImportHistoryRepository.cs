using BOMProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOMProject.DataAccess.Repositories
{
    public interface IImportHistoryRepository
    {
        bool ExistsByHash(string fileHash);
        void AddImportHistory(ImportHistory importHistory);
        void ExecuteTransaction(Action action);
        List<ImportHistory> GetAllImportHistories();
        void SaveChanges();
    }
}
