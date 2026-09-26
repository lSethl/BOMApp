using System;
using System.Collections.Generic;
using System.Text;
using BOMProject.Entities;
using BOMProject.DataAccess.Context;

namespace BOMProject.DataAccess.Repositories
{
    public class ImportHistoryRepository : IImportHistoryRepository
    {
        private readonly AppDbContext _context;
        public ImportHistoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddImportHistory(ImportHistory importHistory)
        {
            _context.ImportHistories.Add(importHistory);
        }

        public void ExecuteTransaction(Action action)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                action();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public bool ExistsByHash(string fileHash)
        {
            return _context.ImportHistories
                .Any(h => h.FileHash == fileHash);
        }

        public List<ImportHistory> GetAllImportHistories()
        {
            return _context.ImportHistories.OrderByDescending(x => x.ImportedAt).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
