using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites;

namespace Talabat.core.Services
{
    public interface IpaymentServes
    {
        Task<CustmerBasket> CreatOrUpdatPaymentIntentd(string basketId);

    }
}
