using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Talabat.core.Entites;
using Talabat.core.IReposateres;
using Talabat.core.Spasifcation;

namespace Talabat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IGenaricReposatery<Employee> empRepo;
        private readonly IMapper _mapper;

        public EmployeeController(IGenaricReposatery<Employee> EmpRepo,IMapper mapper)
        {
            empRepo = EmpRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmp()
        {
            var spec = new EmployeeSpasifcation();
            var Emp = await empRepo.GetAllWithSpecAsync(spec)
                ;
            return Ok(Emp);
        }
    }
}
