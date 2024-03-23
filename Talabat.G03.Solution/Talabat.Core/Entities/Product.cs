using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities;

public class Product:BaseEntity
{
    
    public string Name{ get; set; }
    public string Description { get; set; }
    public string PictureURL { get; set; }
    public decimal Price { get; set;}
 
    public int BrandId { get; set; } //Foregin key coulmn => ProductBrand
    public ProductBrand Brand { get; set;} //Navigational Property [ONE]
    public int CategoryId { get; set; }//Foregin key coulmn => ProductCategory
    public ProductCategory Category { get; set; }//Navigational Property [ONE]
}
