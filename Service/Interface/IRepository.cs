using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> expression);
        Task<List<T>> GetAll();
        void Add(T item);
        void Remove(T item);
        void RemoveRange(IEnumerable<T> items);

    }
}
