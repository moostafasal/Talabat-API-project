using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;
using Talabat.core.Entites;
using Talabat.core.IReposateres;
using Talabat.DTOS;

namespace Talabat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBascketReposatry bascketReposatry;
        private readonly IMapper _mapper;

        public BasketController(IBascketReposatry bascketReposatry,IMapper mapper)
        {
            this.bascketReposatry = bascketReposatry;
            _mapper = mapper;
        }

        [HttpGet]//=>get
        public async Task<ActionResult<CustmerBasket>>GetbasketById( string Id)
        {
            var basket =await bascketReposatry.GetBasketAsync(Id);
            return Ok(basket ?? new CustmerBasket(Id));
        }
        [HttpPost]// api/basket
                  //make validat for the basket using dto 
        
        public async Task<ActionResult<CustmerBasket>> updateBasket(CustmuerBasketDto basket)
        {
            var MappBasket = _mapper.Map<CustmuerBasketDto, CustmerBasket>(basket);
            var UC= await bascketReposatry.UpdatBascket(MappBasket);
            return Ok(UC);

         }
        [HttpDelete]
        public async Task Detet(string Id)
        {
            await bascketReposatry.DeletBasket(Id);

        }

    }
}
