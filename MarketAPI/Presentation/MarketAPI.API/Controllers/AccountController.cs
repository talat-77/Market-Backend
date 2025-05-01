using MarketAPI.Application.Abstractions.Token;
using MarketAPI.Application.DTO;
using MarketAPI.Application.DTO.Customer;
using MarketAPI.Application.DTO.User;
using MarketAPI.Domain.Entities;
using MarketAPI.Infrastructure.Services.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarketAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, ITokenHandler tokenHandler)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenHandler = tokenHandler;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUserDto )
        {
          if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new User
            {
                UserName=registerUserDto.Email,
                Email=registerUserDto.Email,
                Name=registerUserDto.Name,  
                Surname=registerUserDto.Surname
                
            };

            var result  = await _userManager.CreateAsync(user,registerUserDto.Password);
            if(result.Succeeded)
            {
                return Ok(new { message = "Kayıt Başarılı" });
            }
            return BadRequest(result.Errors);  

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto _login )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userManager.FindByEmailAsync(_login.Email);
            if (user == null)
            {
                return Unauthorized("Invalid credentials");
            }
            var result = await _signInManager.PasswordSignInAsync(user, _login.Password, false, false);

            if (result.Succeeded)
            {
                
               var token = _tokenHandler.CreateAccessToken(5);
                return Ok(new
                {
                    token = token.AccessToken,
                    expiration = token.Expiration,
                    message = "Giriş Başarılı"

                });
                

            }
            return Unauthorized("Invalid credentials");
        }

    }
}
