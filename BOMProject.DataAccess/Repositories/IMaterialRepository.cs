using System;
using BOMProject.Entities;

namespace BOMProject.DataAccess.Repositories
{
    public interface IMaterialRepository
    {
        void AddMaterial(Material material);
        void UpdateMaterial(Material material);
        Material? GetById(int id);
        void DeleteMaterial(int id);
        List<Material> GetAllMaterials();   
        List<Material> SearchMaterials(string searchText, string searchField);
        Material? GetByCommentAndFootprint(string comment, string footprint);
        void AddMaterialWithoutSave(Material material);
        void UpdateMaterialWithoutSave(Material material);
        void DeleteZeroQuantityMaterials();
    }
}
