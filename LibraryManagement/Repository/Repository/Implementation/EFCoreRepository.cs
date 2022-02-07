using DomainModel.Models.Base;
using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Implementation
{
    public class EFCoreRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly AppDbContext db;


        public EFCoreRepository(AppDbContext Db)
        {
            db = Db;
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }
        public async Task<bool> AddAsync(List<T> items)
        {
            try
            {
                await db.Set<T>().AddRangeAsync(items);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public async Task<bool> AddAsync(params T[] items)
        {

            try
            {
                await db.Set<T>().AddRangeAsync(items);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> AddAsync(T item)
        {
            try
            {
                await db.Set<T>().AddAsync(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteAsync(List<T> items)
        {
            db.Set<T>().RemoveRange(items);
            await db.SaveChangesAsync();
            return true;

        }

        public async Task<bool> DeleteAsync(params T[] items)
        {
            db.Set<T>().RemoveRange(items);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(T item)
        {
            db.Set<T>().Remove(item);
            await db.SaveChangesAsync();
            return true;
        }


        public async Task<bool> Update(List<T> items)
        {
            try
            {
                db.Set<T>().UpdateRange(items);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> Update(params T[] items)
        {
            try
            {
                db.Set<T>().UpdateRange(items);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> Update(T item)
        {
            try
            {
                db.Set<T>().Update(item);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
