using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites;

namespace Talabat.core.IReposateres
{
    public interface IBascketReposatry
    {
        Task<CustmerBasket> GetBasketAsync(string BasketId);
        Task<CustmerBasket> UpdatBascket(CustmerBasket basket);
        Task<bool> DeletBasket(string BasketId);

    }
}
