using Microsoft.Extensions.Configuration;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.core.Entites;
using Talabat.core.Entites.OrderAgregt;
using Talabat.core.IReposateres;
using Talabat.core.Services;

namespace Talabat.Serves
{
    public class PaymentServes : IpaymentServes
    {
        private readonly IBascketReposatry _bascket;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentServes(IConfiguration configuration,IBascketReposatry bascket,IUnitOfWork unitOfWork)
        {
            Configuration = configuration;
            _bascket = bascket;
            _unitOfWork = unitOfWork;
        }

        public IConfiguration Configuration { get; }

        public async Task<CustmerBasket> CreatOrUpdatPaymentIntentd(string basketId)
        {
            //secretke
            StripeConfiguration.ApiKey = Configuration["stripeSettings:Secretkey"];
            var basket = await _bascket.GetBasketAsync(basketId);
            if (basket == null) return null;
            //delvery method
            var shpingPrice = 0m;
            if (basket.DelveryMethodId.HasValue)
            {
                var delveryMethod = await _unitOfWork.reposatery<DelveryMethod>().GetIdAsync(basket.DelveryMethodId.Value);
                shpingPrice = delveryMethod.Cost;
                basket.shpingPrice = shpingPrice;
            }
            //get product price from databeas   
            foreach (var item in basket.Items)
            {
                var product = await _unitOfWork.reposatery<product>().GetIdAsync(item.Id);
                if (product.Price != item.price)
                    item.price = product.Price;
                    

            }
            PaymentIntent intend;
            //create payment intend
            if (string.IsNullOrEmpty(basket.paymentIntend))
            {
                var options = new PaymentIntentCreateOptions();
            }

            return
            
        }
    }
}
