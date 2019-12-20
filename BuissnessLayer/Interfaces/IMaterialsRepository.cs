using DataLayer.Entityes;
using System.Collections.Generic;

namespace BuissnessLayer.Interfaces
{
    public interface IMaterialsRepository
    {
        IEnumerable<Material> GetAllMaterials(bool includeDirectory = false);
        Material GetMaterialById(int materialId, bool includeDirectory = false);
        void SaveDirectory(Material material);
        void DeleteDirectory(Material material);
    }
}
