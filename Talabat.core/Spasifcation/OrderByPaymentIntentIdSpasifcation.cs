using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites.OrderAgregt;

namespace Talabat.core.Spasifcation
{
    public class OrderByPaymentIntentIdSpasifcation : BaseSpasifcation<Order>
    {
        public OrderByPaymentIntentIdSpasifcation(string paymentIntentId) : base(x => x.PaymentIntentId == paymentIntentId)
        {

        }
    }
    
}
