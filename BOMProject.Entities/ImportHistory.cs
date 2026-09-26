using System;
using System.Collections.Generic;
using System.Text;

namespace BOMProject.Entities
{
    public class ImportHistory
    {
        public int Id { get; set; }
        public string? FileHash { get; set; }
        public string? FileName { get; set; }
        public DateTime ImportedAt { get; set; }
    }
}
