using DomainModel.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Abstraction
{
    public interface IRepository<T> where T : IEntity
    {
        Task<IList<T>> GetAllAsync();

        Task<T> GetAsync(int id);


        Task<bool> AddAsync(List<T> items);
        Task<bool> AddAsync(params T[] items);
        Task<bool> AddAsync(T item);

        Task<bool> Update(List<T> items);
        Task<bool> Update(params T[] items);
        Task<bool> Update(T item);

        Task<bool> DeleteAsync(List<T> items);
        Task<bool> DeleteAsync(params T[] items);
        Task<bool> DeleteAsync(T item);



    }
}
