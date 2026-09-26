using BOMProject.DataAccess.Context;
using BOMProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;


namespace BOMProject.DataAccess.Repositories
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly AppDbContext _context;
        public MaterialRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddMaterial(Material material)
        {
            _context.Materials.Add(material);
            _context.SaveChanges();
        }
        public void UpdateMaterial(Material material)
        {
            _context.Materials.Update(material);
            _context.SaveChanges();
        }
        public Material? GetById(int id)
        {
            return _context.Materials.Find(id);
        }
        public void DeleteMaterial(int id)
        {
            var material = _context.Materials.Find(id);
            if (material != null)
            {
                _context.Materials.Remove(material);
                _context.SaveChanges();
            }
        }
        public List<Material> GetAllMaterials()
        {
            return _context.Materials.ToList();
        }
        public List<Material> SearchMaterials(string searchText, string searchField)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return GetAllMaterials();
            }

            searchText = searchText.Trim().ToLower();

            return searchField switch
            {
                "Comment" => _context.Materials
                    .Where(m => m.Comment != null &&
                                m.Comment.ToLower().Contains(searchText))
                    .ToList(),

                "Footprint" => _context.Materials
                    .Where(m => m.Footprint != null &&
                                m.Footprint.ToLower().Contains(searchText))
                    .ToList(),

                "Value" => _context.Materials
                    .Where(m => m.Value != null &&
                                m.Value.ToLower().Contains(searchText))
                    .ToList(),

                "All Fields" => _context.Materials
                    .Where(m =>
                        (m.Comment != null &&
                         m.Comment.ToLower().Contains(searchText)) ||

                        (m.Footprint != null &&
                         m.Footprint.ToLower().Contains(searchText)) ||

                        (m.Value != null &&
                         m.Value.ToLower().Contains(searchText)))
                    .ToList(),

                _ => new List<Material>()
            };
        }

        public Material? GetByCommentAndFootprint(string comment, string footprint)
        {
            return _context.Materials
                .FirstOrDefault(m => m.Comment == comment && m.Footprint == footprint);
        }

        public void AddMaterialWithoutSave(Material material)
        {
            _context.Materials.Add(material);
        }

        public void UpdateMaterialWithoutSave(Material material)
        {
            _context.Materials.Update(material);
        }

        public void DeleteZeroQuantityMaterials()
        {
            var materials = _context.Materials
        .Where(x => x.Quantity == 0)
        .ToList();

            if (materials.Count == 0)
                return;

            _context.Materials.RemoveRange(materials);
            _context.SaveChanges();
        }
    }
}
