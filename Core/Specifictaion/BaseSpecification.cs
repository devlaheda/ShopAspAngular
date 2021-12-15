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

        public Expression<Func<TEntity, object>> OrderByAsc {get; private set;}

        public Expression<Func<TEntity, object>> OrderByDesc {get; private set;}

        public int Take {get;private set;}

        public int Skip {get;private set;}

        public bool IsPaginationEnabled {get;private set;}

        protected void AddInclude(Expression<Func<TEntity,object>> include)
        {
            Includes.Add(include);    
        }
        protected void AddOrderByAsc(Expression<Func<TEntity,object>> orderByAsc){
            OrderByAsc = orderByAsc;
        }

        protected void AddOrderByDesc(Expression<Func<TEntity,object>> orderByDesc){
            OrderByDesc = orderByDesc;
        }
        protected void AddPagination(int skip,int take){
            Skip = skip;
            Take = take;
            IsPaginationEnabled = true;
        }
    }
}