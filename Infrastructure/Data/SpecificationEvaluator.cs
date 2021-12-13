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
            if (spec.Criteria is not null)
            {
                inputquey.Where(spec.Criteria);
            }
            inputquey = spec.Includes.Aggregate(inputquey,(current ,include)=> current.Include(include));
            return inputquey;
        }
    }
}