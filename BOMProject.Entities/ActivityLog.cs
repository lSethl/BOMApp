using System;
using System.Collections.Generic;
using System.Text;

namespace BOMProject.Entities
{
    public class ActivityLog
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
