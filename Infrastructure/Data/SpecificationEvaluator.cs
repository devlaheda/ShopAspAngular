using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> query,ISpecification<T> spec)
        {
            var inputquey = query;
            if (spec.Criteria != null)
            {
               inputquey = inputquey.Where(spec.Criteria);
            }
            if (spec.OrderByAsc != null)
            {
               inputquey = inputquey.OrderBy(spec.OrderByAsc);
            }
            if (spec.OrderByDesc != null)
            {
               inputquey = inputquey.OrderByDescending(spec.OrderByDesc);
            }
            if (spec.IsPaginationEnabled)
            {
                inputquey = inputquey.Skip(spec.Skip).Take(spec.Take);
            }
            inputquey = spec.Includes.Aggregate(inputquey,(current ,include)=> current.Include(include));
            return inputquey;
        }
    }
}