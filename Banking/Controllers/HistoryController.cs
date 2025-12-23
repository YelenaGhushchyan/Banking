using Banking.Domain.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistoryController(IHistoryService service) : ControllerBase
    {
        [HttpPost("Add deposit")]
        public async Task<IActionResult> Deposit(int customerId,decimal amount)
        {
            var dep = await service.DepositBalance(customerId, amount);
            return Ok(dep);
        }

        [HttpPost("Withdraw")]
        public async Task<IActionResult> Withdraw(int customerId, decimal amount)
        {
            var dep = await service.WithDrow(customerId, amount);
            return Ok(dep);
        }


        [HttpGet("history")]
        public async Task<IActionResult> GetHistory(int customerId, int pageNumber = 1, int pageSize = 10)
        {
            var data = await service.GetCustomerHistory(customerId, pageNumber, pageSize);
            return Ok(data);
        }
    }
}
