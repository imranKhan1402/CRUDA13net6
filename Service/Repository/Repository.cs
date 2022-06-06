using Microsoft.EntityFrameworkCore;
using Model.Context;
using Service.Interface;
using SideClass.HelpingClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CardsDbContext cardsDbContext;
        internal DbSet<T> dbSet;
        public Repository(CardsDbContext _cardsDbContext)
        {
            cardsDbContext = _cardsDbContext;
            this.dbSet = cardsDbContext.Set<T>();
        }
        public void Add(T item)
        {
            //dbSet.Add(item);
            dbSet.AddAsync(item);
            //return await Task.FromResult(SideHelper.DepartmentObjectStringBuilder(item, "Created").Result.ToString());
        }

        public async Task<List<T>> GetAll()
        {
            IQueryable<T> query = dbSet;
            return await query.ToListAsync();
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> expression)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(expression);
            return await query.FirstOrDefaultAsync();
        }

        public void Remove(T item)
        {
            dbSet.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
           dbSet.RemoveRange(items);
        }
    }
}
