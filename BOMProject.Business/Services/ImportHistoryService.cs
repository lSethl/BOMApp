using BOMProject.Business.Contracts;
using BOMProject.DataAccess.Repositories;
using BOMProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOMProject.Business.Services
{
    public class ImportHistoryService : IImportHistoryService
    {
        private readonly IImportHistoryRepository _importHistoryRepository;
        public ImportHistoryService(IImportHistoryRepository importHistoryRepository)
        {
            _importHistoryRepository = importHistoryRepository;
        }
        public List<ImportHistory> GetAllImportHistories()
        {
            return _importHistoryRepository.GetAllImportHistories();
        }
    }
}
