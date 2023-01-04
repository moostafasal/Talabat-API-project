using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Talabat.core.Entites;
using Talabat.core.IReposateres;
using Talabat.core.Spasifcation;
using Talabat.DTOS;
using Talabat.Errors;
using Talabat.Helper;

namespace Talabat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenaricReposatery<product> _proudctRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenaricReposatery<product> proudctRepo,IMapper mapper)
        {
            _proudctRepo = proudctRepo;
            _mapper = mapper;
        }
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]//=>GET
        public async Task<ActionResult<Pagin<ProductDTO>>> Getproudct([FromQuery] Productparams productParams)
        {
            var spec = new productwithprandtybeSpasification(productParams); 
            var products = await _proudctRepo.GetAllWithSpecAsync(spec);
            var Data = _mapper.Map<IEnumerable<product>, IEnumerable<ProductDTO>>(products);
            var countspec = new ProductWithFiltaar(productParams);//to count spasifc product not all  XX
            var Count = await _proudctRepo.CountAsync(countspec);
            return Ok(new Pagin<ProductDTO>(productParams.pageIndex, productParams.Pagesize,Data,Count));

        }
        //creat product by admin
       
        

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductbyid(int id)
        {
            var spec = new productwithprandtybeSpasification(id);
         
            var product = await _proudctRepo.GetIdwithspecAsync(spec);
            if (product == null) return NotFound(new Api_Response(404));
            return Ok(_mapper.Map <product, ProductDTO>(product));

        }


        

    }
}
