using System;
namespace BOMProject.Entities
{
    public class Material
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string? Comment { get; set; }
        public string? Footprint { get; set; }
        public string? Value { get; set; }
        public string? Location { get; set; }
        public string? ImagePath { get; set; }
    }
}
