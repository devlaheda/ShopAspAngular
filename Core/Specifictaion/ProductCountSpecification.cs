using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifictaion
{
    public class ProductCountSpecification : BaseSpecification<Product>
    {
        public ProductCountSpecification( ProductsSpecParams specParams)
        :base(x => 
        (string.IsNullOrEmpty(specParams.Search)|| x.Name.ToLower().Contains(specParams.Search))&&
        (!specParams.BrandId.HasValue || specParams.BrandId == x.ProductBrandId ) && 
        (!specParams.TypeId.HasValue ||specParams.TypeId == x.ProductTypeId) )
        {
            
        }
    }
}