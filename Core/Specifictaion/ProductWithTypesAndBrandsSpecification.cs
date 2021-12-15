using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifictaion
{
    public class ProductWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductWithTypesAndBrandsSpecification(ProductsSpecParams productsSpecParams)
            :base(x => 
                    (string.IsNullOrEmpty(productsSpecParams.Search) || x.Name.ToLower().Contains(productsSpecParams.Search))&&
                    (!productsSpecParams.TypeId.HasValue || x.ProductTypeId == productsSpecParams.TypeId )&&
                    (!productsSpecParams.BrandId.HasValue || x.ProductBrandId == productsSpecParams.BrandId))
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(p=> p.ProductType);
            AddOrderByAsc(p => p.Name);
            AddPagination(productsSpecParams.PageSize*(productsSpecParams.PageIndex - 1) , productsSpecParams.PageSize);
            if (!string.IsNullOrEmpty(productsSpecParams.Sort))
            {
                switch (productsSpecParams.Sort)
                {
                    case "priceAsc" : AddOrderByAsc(p => p.Price);
                        break;
                    case "priceDesc" : AddOrderByDesc(p => p.Price);
                        break;
                    default: 
                        break;
                }
            }
        }
        public ProductWithTypesAndBrandsSpecification(int id) : base(p => (p.Id == id)) 
        {
            AddInclude(p=> p.ProductBrand);
            AddInclude(p=> p.ProductType);                  
        }

    }
}