using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites;
using Talabat.core.IReposateres;
using Talabat.core.Spasifcation;
using TalabatReposatrey.Data;

namespace TalabatReposatrey
{
    public class GenaricReposatrey<T> : IGenaricReposatery<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenaricReposatrey(StoreContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            //if (typeof(T) == typeof(product))
            //{
            //    return (IEnumerable<T>) _context.Set<product>().Include(p => p.productbrand).Include(p => p.ProductType);
            //}
        

       return    await _context.Set<T>().ToListAsync();

        }
        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(Ispasifcation<T> spec)
        {

            return await ApplySpasifcation(spec).ToListAsync();

        }
        public async Task<T> GetIdwithspecAsync(Ispasifcation<T> spec)
        {

            return await ApplySpasifcation(spec).FirstOrDefaultAsync();

        }

        public async Task<T> GetIdAsync(int id)
            =>await _context.Set<T>().FindAsync(id);

        public async Task<int> CountAsync(Ispasifcation<T> spec)
        {
            return await ApplySpasifcation(spec).CountAsync();



        }
        private IQueryable<T> ApplySpasifcation(Ispasifcation<T> spec)
        {
            return SpaceficationEvaluat<T>.GetQurey(_context.Set<T>(), spec);
        }

        public async Task CreatAsync(T entity)
        {
          await  _context.Set<T>().AddAsync(entity);
        }

        public void UpdateAsync(T entity)
        {
            //_context.Set<T>().Attach(entity);
            //_context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);


        }

        public void DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }

}
