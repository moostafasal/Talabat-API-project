using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites;
using Talabat.core.Spasifcation;

namespace Talabat.core.IReposateres
{
    public interface IGenaricReposatery<T> where T:BaseEntity
    {

        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllWithSpecAsync(Ispasifcation<T> spec);

        Task<T> GetIdAsync(int id);
        Task<T> GetIdwithspecAsync(Ispasifcation<T> spec);

        Task<int> CountAsync(Ispasifcation<T> spec);

        Task CreatAsync(T entity);
       void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        
    }
}
