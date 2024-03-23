using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Talabat.Core.Entities;

namespace Talabat.Core.Data;

public class StoreContext: DbContext
{
    //chain to parameterized constractor obj of
    ////retrieve the options and pass that to base class of DB context
    public StoreContext(DbContextOptions<StoreContext>optians)
         :base(optians)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //apply configurations
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
        //base.OnModelCreating(modelBuilder);
    }
    //Tables
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductBrand>ProductBrands { get; set; }
    public DbSet<ProductCategory>ProductCategories { get; set; }
}
