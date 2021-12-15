using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ISpecification<T> where T : BaseEntity
    {
        Expression<Func<T,bool>> Criteria{get;}
        List<Expression<Func<T,object>>> Includes{get;}

        Expression<Func<T,object>> OrderByAsc{get;}
        Expression<Func<T,object>> OrderByDesc{get;}

        int Take {get;}
        int Skip{get;}
        bool IsPaginationEnabled {get;}
        
    }
}