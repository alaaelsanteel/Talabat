using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Talabat.Core.Data;
using Talabat.Core.Entities;

namespace Talabat.Repository.Data
{
    public static class StoreContextSeed
    {
        public async static Task SeedAsync(StoreContext _dbContext)
        {
            if (!_dbContext.ProductBrands.Any()) //doesn't contain any elements to seed only one time
            {
                var brandsData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brands?.Count() > 0)
                {

                    foreach (var brand in brands)
                    {
                        _dbContext.Set<ProductBrand>().Add(brand);
                    }
                    await _dbContext.SaveChangesAsync();
                } 
            }

            if (!_dbContext.ProductCategories.Any())
            {
                var categoriesData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/categories.json");
                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);
                if(categories?.Count()>0)
                {
                    foreach(var category in categories)
                    {
                        _dbContext.Set<ProductCategory>().Add(category);
                    }
                    await _dbContext.SaveChangesAsync();
                }   
            
            }

            if(!_dbContext.Products.Any())
            {
                var productData = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/products.json"); 
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
                if (products?.Count() > 0)
                {
                    foreach (var product in products)
                    {
                        _dbContext.Set<Product>().Add(product);
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

    }
}
