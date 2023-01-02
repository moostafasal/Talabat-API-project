using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites;
using Talabat.core.Entites.OrderAgregt;
using Talabat.core.IReposateres;
using Talabat.core.Services;
using Talabat.core.Spasifcation;

namespace Talabat.Serves
{
    public class OrderServeis : IOrderServes
    {
        private readonly IBascketReposatry bascket;
        private readonly IUnitOfWork _unitOfWork;

        //private readonly IGenaricReposatery<product> productOrder;
        //private readonly IGenaricReposatery<DelveryMethod> deleveryMethod;
        //private readonly IGenaricReposatery<Order> orederRepo;

        public OrderServeis(IBascketReposatry bascket,IUnitOfWork unitOfWork)
            //IGenaricReposatery<product> productOrder,
            //IGenaricReposatery<DelveryMethod> deleveryMethod,
            //IGenaricReposatery<Order> OrederRepo)
        {
            this.bascket = bascket;
          _unitOfWork = unitOfWork;
            //this.productOrder = productOrder;
            //this.deleveryMethod = deleveryMethod;
            //orederRepo = OrederRepo;
        }
        public async Task<Order> CeratOredrAsync(string BuyerEmail, string BascketId, int deleveryMethodId, Address shipingAddress)
        {
            //creat order 
            //Get Basket Forom Basket Reposatrey
            var basketRepo = await bascket.GetBasketAsync(BascketId);

            //get selct item from bascket
            var orderItems = new List<OrderItem>();
            foreach (var item in basketRepo.Items)
            {
                var product = await _unitOfWork.reposatery<product>().GetIdAsync(item.Id);
                var productItem = new productItemOrder(product.Id, product.Name, product.PictureUrl);
                var itemOrder = new OrderItem(productItem, product.Price, item.Quantity);

                orderItems.Add(itemOrder);
                //select item forom bascket
                

               
            }

            var subtotal = orderItems.Sum(item => item.price * item.Quantity);
            //get delevery method from delevery repo
            var deliveryMethod = await _unitOfWork.reposatery<DelveryMethod>().GetIdAsync(deleveryMethodId);

            //creat order
            var order = new Order(BuyerEmail, shipingAddress, deliveryMethod, subtotal, orderItems);
         await _unitOfWork.reposatery<Order>().CreatAsync(order);
            //save changes in DB
           var result= await _unitOfWork.complet();
            if(result<=0)
                return null;
            return order;
        }

        public async Task<IReadOnlyList<DelveryMethod>> GetDeleveryMethod()
        {
       var result=await     _unitOfWork.reposatery<DelveryMethod>().GetAllAsync();
            return result ;
        }

        public async Task<Order> GetOrderByIdForUserAsync(int orderId, string buyerEmail)
        {
            var spec = new OrderWithItemsAndDelveryMethodSpasefcation(orderId, buyerEmail);
            var order = await _unitOfWork.reposatery<Order>().GetIdwithspecAsync(spec);
            return order;
        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string BuyerEmail)
        {
            //get order for user by email
            var spec =new OrderWithItemsAndDelveryMethodSpasefcation(BuyerEmail);
            var orders = _unitOfWork.reposatery<Order>().GetAllWithSpecAsync(spec);
            return orders;


        }
    }
}
