using Banking.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace Banking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(ICustomer service) : ControllerBase
    {
        [HttpPost("create-Customer")]
        public async Task<IActionResult> Create(string Name,string Email)
        {
            var cus = await service.CreateCustomer(Name, Email);
            return Ok(cus);
        }
    }
}
