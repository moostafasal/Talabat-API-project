using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Talabat.core.Entites.Identity;
using Talabat.core.Entites.OrderAgregt;
using Talabat.core.Services;
using Talabat.DTOS;
using Talabat.Errors;
using Address = Talabat.core.Entites.OrderAgregt.Address;

namespace Talabat.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServes _orderServes;
        private readonly IMapper _mapper;

        public OrdersController(IOrderServes orderServes,IMapper mapper)
        {
            _orderServes = orderServes;
            _mapper = mapper;
        }
        [HttpPost]//Api/Orders
        public async Task<ActionResult<OrderToDto>> CreateOrder(OrderDto orderDto)
            
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var orderAddresmap = _mapper.Map<AddressDto, Address>(orderDto.ShipToAddress);
            var order = await _orderServes.CeratOredrAsync(buyerEmail, orderDto.basketId, orderDto.DeliveryMethodId, orderAddresmap);
            if (order == null) return BadRequest(new Api_Response(400));
            return Ok(_mapper.Map<Order, OrderToDto>(order));

        }
        //get order 
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<OrderToDto>>> GetOrderForUser()
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);

            var oredrs =await _orderServes.GetOrdersForUserAsync(buyerEmail);

            return Ok(_mapper.Map<IReadOnlyList<Order>, IReadOnlyList<OrderToDto>>(oredrs));

        }
        //get order by id   
        [HttpGet("{id}")]
        public async Task<ActionResult<IReadOnlyList<OrderToDto>>> GetorderForUserById(int id)
        {
            var buyerEmail = User.FindFirstValue(ClaimTypes.Email);
            var oredr = await _orderServes.GetOrderByIdForUserAsync(id , buyerEmail);

            if (oredr == null) return BadRequest(new Api_Response(400));
            return Ok(_mapper.Map<Order, OrderToDto>(oredr));
        }
        // get delvery method
        [HttpGet("(deleverymethod)")]
        public async Task<ActionResult<IReadOnlyList<DelveryMethod>>> GetAllMethod()
        {
            var DeleveryMethod = await _orderServes.GetDeleveryMethod();
            return Ok(DeleveryMethod);
        }
    }
}
