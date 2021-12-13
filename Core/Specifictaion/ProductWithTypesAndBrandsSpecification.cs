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
        public ProductWithTypesAndBrandsSpecification()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(p=> p.ProductType);
        }

        public ProductWithTypesAndBrandsSpecification(int id) : base(p => (p.Id == id)) 
        {
            AddInclude(p=> p.ProductBrand);
            AddInclude(p=> p.ProductType);                  
        }

    }
}