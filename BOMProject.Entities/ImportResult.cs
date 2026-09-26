using System;
using System.Collections.Generic;
using System.Text;

namespace BOMProject.Entities
{
    public class ImportResult
    {
        public int ProcessedMaterialCount { get; set; }
        public string FileName { get; set; } = string.Empty;
        public DateTime ImportedAt { get; set; }
        public List<string> Warnings { get; set; } = new();
    }
}
