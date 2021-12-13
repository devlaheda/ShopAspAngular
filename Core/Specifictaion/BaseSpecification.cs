using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;

namespace Core.Specifictaion
{
    public class BaseSpecification<TEntity> : ISpecification<TEntity> where TEntity : BaseEntity
    {
        public BaseSpecification()
        {
            Includes = new List<Expression<Func<TEntity, object>>>();
        }

        public BaseSpecification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
            Includes = new List<Expression<Func<TEntity, object>>>();
        }

        public Expression<Func<TEntity, bool>> Criteria  {get;}

        public List<Expression<Func<TEntity, object>>> Includes {get;}

        protected void AddInclude(Expression<Func<TEntity,object>> include)
        {
            Includes.Add(include);    
        }
    }
}