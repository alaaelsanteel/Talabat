using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities;

public class ProductBrand: BaseEntity
{
    public string Name { get; set; }
    //public ICollection<Product> Products { get; set; } = new HashSet<Product>();//this part won't be used
    // from brand accessing his product so the relation will be configured using fluent api without it will be one-one
}
