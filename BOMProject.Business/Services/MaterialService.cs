using System;
using System.Collections.Generic;
using System.Text;
using BOMProject.Entities;
using BOMProject.Business.Contracts;
using BOMProject.DataAccess.Repositories;


namespace BOMProject.Business.Services
{
    public class MaterialService : IMaterialService
    {
        private readonly IMaterialRepository _materialRepository;
        public MaterialService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
        }

        public void DecreaseQuantity(int materialId, int quantityToDecrease)
        {
            var material = _materialRepository.GetById(materialId);

            if (material == null)
                throw new Exception("Ürün bulunamadı.");

            if (quantityToDecrease <= 0)
                throw new Exception("Azaltılacak miktar 0'dan büyük olmalıdır.");

            if (quantityToDecrease > material.Quantity)
                throw new Exception("Azaltılacak miktar mevcut miktardan fazla olamaz.");

            material.Quantity -= quantityToDecrease;

            if (material.Quantity == 0)
            {
                DeleteMaterial(material.Id);
            }
            else
            {
                _materialRepository.UpdateMaterial(material);
            }
        }

        public void DeleteMaterial(int materialId)
        {
            var material = _materialRepository.GetById(materialId);

            if (material == null)
                throw new Exception("Ürün bulunamadı.");

            // Ürüne ait resmi sil
            DeleteMaterialImage(material.ImagePath);

            // Ürünü veritabanından sil
            _materialRepository.DeleteMaterial(materialId);
        }

        public void DeleteZeroQuantityMaterials()
        {
            var zeroQuantityMaterials = _materialRepository
        .GetAllMaterials()
        .Where(x => x.Quantity == 0)
        .ToList();

            foreach (var material in zeroQuantityMaterials)
            {
                DeleteMaterial(material.Id);
            }
        }

        public List<Material> GetAllMaterials()
        {
            return _materialRepository.GetAllMaterials();
        }

        public void ProcessMaterial(Material material)
        {
            Material? existingMaterial = null;

            if (!string.IsNullOrWhiteSpace(material.Comment) &&
                !string.IsNullOrWhiteSpace(material.Footprint))
            {
                existingMaterial =
                    _materialRepository.GetByCommentAndFootprint(
                        material.Comment,
                        material.Footprint);
            }

            if (existingMaterial != null)
            {
                existingMaterial.Quantity += material.Quantity;
                _materialRepository.UpdateMaterialWithoutSave(existingMaterial);
            }
            else
            {
                _materialRepository.AddMaterialWithoutSave(material);
            }
        }

        public string SaveMaterialImage(string sourceFilePath)
        {
            string imageFolder = Path.Combine(
        Environment.GetFolderPath(
            Environment.SpecialFolder.LocalApplicationData),
        "BomApp",
        "Images");

            Directory.CreateDirectory(imageFolder);

            string extension = Path.GetExtension(sourceFilePath);
            string fileName = $"{Guid.NewGuid()}{extension}";
            string destinationPath = Path.Combine(imageFolder, fileName);

            File.Copy(sourceFilePath, destinationPath);

            return destinationPath;
        }

        public List<Material> SearchMaterials(string searchText, string searchField)
        {
            return _materialRepository.SearchMaterials(searchText, searchField);
        }

        public void UpdateMaterial(Material material)
        {
            _materialRepository.UpdateMaterial(material);
        }

        public void DeleteMaterialImage(string? imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath))
                return;

            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
            }
        }

        public void BackupDatabase()
        {
            string appFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "BomApp");

            string databasePath = Path.Combine(appFolder, "BomApp.db");
            string backupFolder = Path.Combine(appFolder, "Backups");

            if (!File.Exists(databasePath))
                throw new FileNotFoundException("Veritabanı dosyası bulunamadı.");

            Directory.CreateDirectory(backupFolder);

            string backupFileName =
                $"BomApp_{DateTime.Now:yyyy-MM-dd_HHmmss}.db";

            string backupPath =
                Path.Combine(backupFolder, backupFileName);

            File.Copy(databasePath, backupPath, false);
            var backupFiles = Directory
                 .GetFiles(backupFolder, "BomApp_*.db")
                 .OrderByDescending(File.GetCreationTime)
                 .ToList();

            foreach (var oldBackup in backupFiles.Skip(3))
            {
                File.Delete(oldBackup);
            }

        }
    }
}
