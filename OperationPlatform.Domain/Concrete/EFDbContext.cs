using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// add new references
using System.Data.Entity;
using OperationPlatform.Domain.Entities;
using System.Data.Entity.Infrastructure;

namespace OperationPlatform.Domain.Concrete
{
    // This class need to tell the Entity Framework how to connect to the database
    // Just add a database connection string to the Web.config in the OperationPlatform.WebUI project
    // with the same name as the context class.
    public class EFDbContext : DbContext
    {
        // this property represent a table  "Products"
        // and the type of DbSet "Product" represent rows in this table
        public DbSet<Product> Products { get; set; }
        public DbSet<MemoryUsed> MemoryUseds { get; set; }
        public DbSet<Availability> Availabilitys { get; set; }
        public DbSet<CPUUsed> CPUUseds { get; set; }
        public DbSet<DeviceNetwork> DeviceNetworks { get; set; }
        public DbSet<DeviceDiskUsed> DeviceDiskUseds { get; set; }        

        // fix the model backing the 'EFDbContext' context has changed since the database was created
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
            
        //    modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
        //}
    }
}
