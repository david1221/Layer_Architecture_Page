using BuissnessLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BuissnessLayer.Implementations
{
    public class EFDirectorysRepository : IDirectorysRepository
    {
        private EFDBContext context;
        public EFDirectorysRepository(EFDBContext context)
        {
            this.context = context;
        }
        public void DeleteDirectory(Directory directory)
        {
            context.Directories.Remove(directory);
            context.SaveChanges(); 
        }

        public IEnumerable<Directory> GetAllDirectorys(bool includeMaterials = false)
        {
            if (includeMaterials)
                return context.Set<Directory>().Include(x => x.Material).AsNoTracking().ToList();
            else
                return context.Directories.ToList();
        }

        public Directory GetDirectoryById(int directoryId, bool includeMaterials = false)
        {
            if (includeMaterials)
                return context.Set<Directory>().Include(x => x.Material).AsNoTracking().FirstOrDefault(x => x.Id == directoryId);
            else
                return context.Directories.FirstOrDefault(x => x.Id == directoryId);
        }

        public void SaveDirectory(Directory directory)
        {
            if (directory.Id == 0)
                context.Directories.Add(directory);
            else
                context.Entry(directory).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
