using System;
using System.Collections.Generic;
using System.Text;
using BOMProject.Entities;

namespace BOMProject.Business.Contracts
{
    public interface IMaterialService
    {
        void ProcessMaterial(Material material);
        List<Material> GetAllMaterials();
        List<Material> SearchMaterials(string searchText, string searchField);
        void UpdateMaterial(Material material);
        string SaveMaterialImage(string sourceFilePath);
        void DecreaseQuantity(int materialId, int quantityToDecrease);
        void DeleteZeroQuantityMaterials();
        void DeleteMaterial(int materialId);
        void DeleteMaterialImage(string? imagePath);
        void BackupDatabase();
    }
}
