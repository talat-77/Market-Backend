using MarketAPI.Application.DTO.Customer;
using MarketAPI.Application.Repositories.CustomerRepository;
using MarketAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;
      

        public CustomerController(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository)
        {
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
            
        }
        [HttpPost("createUser")]
        public async Task<IActionResult> createUser([FromBody] RegisterUserDto registerCustomerDto)
        {
           
            var customer = new Customer
            {
                Name = registerCustomerDto.Name,
               
               
             
            };
            await _customerWriteRepository.AddAsync(customer);
            await _customerWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
