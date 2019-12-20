using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<Material> Materials { get; set; }
        public DbSet<Directory> Directories { get; set; }
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Directory>().HasData(
                new Directory() { Id = 1, Title = "First Directory", Html = "<b>Directory Contexn</b>" },
                new Directory() { Id = 2, Title = "Second Directory", Html = "<b>Directory Contexn</b>"}
                );

            modelBuilder.Entity<Material>().HasData(
                 new Material() { Id=1, Title = "First Materials", Html = "<b>Materials Contexn</b>", DirectoryId = 1 },
                 new Material() { Id = 2, Title = "First Materials", Html = "<b>Materials Contexn</b>", DirectoryId = 2 },
                 new Material() { Id = 3, Title = "First Materials", Html = "<b>Materials Contexn</b>", DirectoryId = 1 }
                );
        }



    }
    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseSqlServer("server = DESKTOP-16VRELJ\\SQLEXPRESS; database = layertestpagedb; trusted_connection = true; Persist Security Info = False; MultipleActiveResultSets = True;", b => b.MigrationsAssembly("DataLayer"));

            return new EFDBContext(optionsBuilder.Options);
        }
    }
}
