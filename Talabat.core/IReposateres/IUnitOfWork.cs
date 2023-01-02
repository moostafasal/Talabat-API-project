using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites;

namespace Talabat.core.IReposateres
{
    public interface IUnitOfWork:IDisposable
    {
        IGenaricReposatery<TEntity> reposatery<TEntity>() where TEntity : BaseEntity;
        Task<int> complet();
    }
}
