using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T:BaseEntity
    {
        Task<T> GetByIdAsync(int Id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdWithSpecsAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAllWithSpecsAsync(ISpecification<T> spec);
        
    }
}