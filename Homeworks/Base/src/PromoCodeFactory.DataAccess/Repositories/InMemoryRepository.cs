using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using PromoCodeFactory.Core.Domain.Administration;
namespace PromoCodeFactory.DataAccess.Repositories
{
    public class InMemoryRepository<T>: IRepository<T> where T: BaseEntity
    {
        protected IEnumerable<T> Data { get; set; }

        public InMemoryRepository(IEnumerable<T> data)
        {
            Data = data;
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(Data);
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            return Task.FromResult(Data.FirstOrDefault(x => x.Id == id));
        }

        public Task<Guid> CreateAsync(T entity)
        {
            Data.ToList().Add(entity);
            return Task.FromResult(entity.Id);
        }

        public async Task<T> UpdateAsync(Guid id, T value)
        {
            var updatedItem = Data.FirstOrDefault(x => x.Id == id);

            updatedItem = value;

            return await Task.FromResult(updatedItem);
        }

        public Task<T> DeleteAsync(Guid id)
        {
            var deletedItem = Data.FirstOrDefault(employee => employee.Id == id);

            Data = Data.Where(employee => employee.Id != id);

            return Task.FromResult(deletedItem);
        }
    }
}