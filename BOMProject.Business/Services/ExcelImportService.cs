using System;
using System.Collections.Generic;
using System.Text;
using BOMProject.Business.Contracts;
using BOMProject.Entities;
using ClosedXML.Excel;
using BOMProject.DataAccess.Repositories;
using System.Security.Cryptography;

namespace BOMProject.Business.Services
{
    public class ExcelImportService : IExcelImportService
    {
        private readonly IMaterialService _materialService;
        private readonly IImportHistoryRepository _importHistoryRepository;
        public ExcelImportService(IMaterialService materialService, IImportHistoryRepository importHistoryRepository)
        {
            _materialService = materialService;
            _importHistoryRepository = importHistoryRepository;
        }

        public ImportResult ImportExcelData(string filePath)
        {
            using var stream = File.OpenRead(filePath);
            string fileHAsh = Convert.ToHexString(SHA256.HashData(stream));
            if (_importHistoryRepository.ExistsByHash(fileHAsh))
            {
                throw new InvalidOperationException(
                    "Bu dosya zaten içeri aktarıldı.");
            }

            using var workbook = new XLWorkbook(filePath);
            var worksheet = workbook.Worksheet(1);

            var rows = worksheet.RowsUsed()
                .Skip(1)
                .Where(row => !row.IsEmpty())
                .ToList();

            if (rows.Count == 0)
            {
                throw new InvalidOperationException(
                    "Excel dosyasında içeri aktarılacak BOM verisi bulunamadı.");
            }

            int processedCount = 0;
            DateTime importedAt = DateTime.Now;
            List<string> warnings = new();

            _importHistoryRepository.ExecuteTransaction(() =>
            {
                foreach (var row in rows)
                {
                    int rowNumber = row.RowNumber();

                    // Quantity kolonunu kontrol et
                    var quantityCell = row.Cell(2);
                    int quantity = 0;

                    if (quantityCell.IsEmpty())
                    {
                        warnings.Add(
                            $"{rowNumber}. satır - Quantity alanı boş. Veri işlendi.");
                    }
                    else if (!quantityCell.TryGetValue<int>(out quantity))
                    {
                        warnings.Add(
                            $"{rowNumber}. satır - Quantity değeri geçersiz. 0 olarak işlendi.");

                        quantity = 0;
                    }

                    // Comment kolonunu kontrol et
                    var comment = row.Cell(3).GetString().Trim();

                    if (string.IsNullOrWhiteSpace(comment))
                    {
                        warnings.Add(
                            $"{rowNumber}. satır - Comment alanı boş. Veri işlendi.");
                    }

                    var optionalFields = new Dictionary<string, string>
                    {
                        { "Footprint", row.Cell(5).GetString().Trim() },
                        { "Value", row.Cell(6).GetString().Trim() },
                    };

                    foreach (var field in optionalFields)
                    {
                        if (string.IsNullOrWhiteSpace(field.Value))
                        {
                            warnings.Add(
                                $"{rowNumber}. satır - {field.Key} alanı boş. Veri işlendi.");
                        }
                    }

                    var material = new Material
                    {
                        Quantity = quantity,
                        Comment = comment,
                        Footprint = optionalFields["Footprint"],
                        Value = optionalFields["Value"],
                    };

                    _materialService.ProcessMaterial(material);
                    processedCount++;
                }

                var importHistory = new ImportHistory
                {
                    FileHash = fileHAsh,
                    FileName = Path.GetFileName(filePath),
                    ImportedAt = importedAt
                };
                _importHistoryRepository.AddImportHistory(importHistory);
                _importHistoryRepository.SaveChanges();
            });

            return new ImportResult
            {
                ProcessedMaterialCount = processedCount,
                FileName = Path.GetFileName(filePath),
                ImportedAt = importedAt,
                Warnings = warnings
            };
        }
    }
}
