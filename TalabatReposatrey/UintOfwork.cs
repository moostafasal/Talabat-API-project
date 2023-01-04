using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites;
using Talabat.core.IReposateres;
using TalabatReposatrey.Data;

namespace TalabatReposatrey
{
    public class UintOfwork : IUnitOfWork
    {
        public UintOfwork(StoreContext context)
        {
           _context = context;
        }   
        private Hashtable _Reposatry;
        private readonly StoreContext _context;

        public async Task<int> complet()
        
          =>   await _context.SaveChangesAsync();
        

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenaricReposatery<TEntity> reposatery<TEntity>() where TEntity : BaseEntity
        {
            if (_Reposatry == null)
                _Reposatry = new Hashtable();
            var type = typeof(TEntity).Name;
            if (!_Reposatry.Contains(type))
            {
                var reposatry = new GenaricReposatrey<TEntity>(_context);
                _Reposatry.Add(type, reposatry);
            }
            return (IGenaricReposatery<TEntity>) _Reposatry[type];
        }
    }
}
