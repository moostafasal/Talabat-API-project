using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Talabat.core.Entites;
using Talabat.core.Services;
using Talabat.Errors;

namespace Talabat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IpaymentServes _paymentServes;

        public PaymentController(IpaymentServes paymentServes)
        {
           _paymentServes = paymentServes;
            
        }
        [HttpPost("{basketId}")]
        public async Task<ActionResult<CustmerBasket>> CreatOrUpdatPaymentIntentd(string basketId)
        {
            var basket = await _paymentServes.CreatOrUpdatPaymentIntentd(basketId);
            if (basket == null) return BadRequest(new Api_Response(400, "problem with your basket"));
            return Ok( basket);
        }
    }
}
