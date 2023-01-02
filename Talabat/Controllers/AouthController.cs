using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Talabat.core.Entites.Identity;
using Talabat.core.Services;
using Talabat.DTOS;
using Talabat.Errors;
using Talabat.Extintions;

namespace Talabat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AouthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITookenServiice _tooken;
        private readonly IMapper mapper;

        public AouthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITookenServiice tooken,IMapper Mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tooken = tooken;
            mapper = Mapper;
        }
        [HttpPost("Login")]

        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var User = await _userManager.FindByEmailAsync(loginDto.Email);
            if (User == null) return Unauthorized(new Api_Response(401));
            var reuslt = await _signInManager.CheckPasswordSignInAsync(User, loginDto.Passowrd, false);
            if (!reuslt.Succeeded) return Unauthorized(new Api_Response(401));
            return Ok(new UserDto()
            {
                DesplyName = User.DesplyName,
                Email = User.Email,
                Token = await _tooken.CreateToken(User, _userManager)
            });

        }
        //login with google acount 
        

        [HttpPost("Regisrt")] //=>API/
        public async Task<ActionResult<UserDto>> Regisrt(RejsterDto RjDTo)
            
        {
            //check if email is exist
            if (CheckEmailExistAsync(RjDTo.Email).Result.Value)
            {
                return new BadRequestObjectResult(new ApiValidationRespons()
                {
                    Errors = new[] {"this Email is Exest alredy"}
                });
            }
            var user = new AppUser() { DesplyName = RjDTo.DesplyName, Email = RjDTo.Email, PhoneNumber = RjDTo.PhoneNumer, UserName = RjDTo.Email.Split("@")[0] };
            var result = await _userManager.CreateAsync(user, RjDTo.Passwroed);
            if (!result.Succeeded) return BadRequest(new Api_Response(400));
            return Ok(new UserDto()
            {
                DesplyName = user.DesplyName,
                Email = user.Email,
                Token = await _tooken.CreateToken(user, _userManager)
            });
        }
        //regester with google acount
        //[HttpPost("RegisrtGoogle")]
        
        ////endpoint for chech if email is exist
        //[HttpGet("emailexist")]
        public async Task<ActionResult<bool>> CheckEmailExistAsync([FromQuery] string email)
        {
            return await _userManager.FindByEmailAsync(email) != null;
        }
        //endpoint for chech if phone is exist
        //[HttpGet("phoneexist")]
        ////public async Task<ActionResult<bool>> CheckPhoneExistAsync([FromQuery] string phone)
        ////{
        ////    return await _userManager.FindByPhoneNumberAsync(phone) != null;
        ////}


        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetcurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            return Ok(new UserDto()
            {
                DesplyName = user.DesplyName,
                Email = user.Email,
                Token = await _tooken.CreateToken(user, _userManager)

            });
    }
        //End point save address

        //what is the rout of this controller   
        
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

        [HttpPut("SaveAddress")]
        public async Task<ActionResult<AddressDto>> SaveAddress(AddressDto addressDto)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            user.Address = mapper.Map<AddressDto, Address>(addressDto);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded) return Ok(mapper.Map<Address, AddressDto>(user.Address));
            return BadRequest(new Api_Response(400) { Massege = "Problem with update address" });
            

        }
        //Get user address
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetAddress")]
        public async Task<ActionResult<AddressDto>> GetAddress()
        {
            

            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindUserWithAddersByEmailAsync(User);
            var result = mapper.Map<Address, AddressDto>(user.Address);
            return Ok(result);
        }
    }
}
