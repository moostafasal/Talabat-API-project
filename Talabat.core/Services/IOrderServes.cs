using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites.OrderAgregt;

namespace Talabat.core.Services
{
    public interface IOrderServes
    {
        Task<Order> CeratOredrAsync(string BuyerEmail, string BascketId, int deleveryMethodId, Address shipingAddress);

        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string BuyerEmail);

        Task<Order> GetOrderByIdForUserAsync(int orderId, string buyerEmail);

        Task<IReadOnlyList<DelveryMethod>> GetDeleveryMethod();
    }
}
