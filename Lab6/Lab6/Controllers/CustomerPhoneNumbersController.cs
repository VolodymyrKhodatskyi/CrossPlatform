using Lab6.Data;
using Lab6.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Lab6.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerPhoneNumbersController : Controller
    {
        private readonly ApplicationContext _context;

        public CustomerPhoneNumbersController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerPhoneNumbers()
        {
            var transactions = await _context.CustomerPhoneNumbers
                .Select(t => new
                {
                    CustomerId = t.CustomerId,
                    CustomerNumberTypeCode = t.CustomerNumberTypeCode,
                    HeldFromDate = t.HeldFromDate,
                    HeldToDate = t.HeldToDate,
                    OtherDetails = t.OtherDetails ?? string.Empty

                })
                .ToListAsync();

            var json = JsonConvert.SerializeObject(transactions, Newtonsoft.Json.Formatting.Indented);
            return Content(json, "application/json");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerPhoneNumbers(int id)
        {
            var transaction = await _context.CustomerPhoneNumbers
                .Where(t => t.CustomerPhoneNumber == id)
                .Select(t => new
                {
                    CustomerId = t.CustomerId,
                    CustomerNumberTypeCode = t.CustomerNumberTypeCode,
                    HeldFromDate = t.HeldFromDate,
                    HeldToDate = t.HeldToDate,
                    OtherDetails = t.OtherDetails ?? string.Empty
                })
                .FirstOrDefaultAsync();

            if (transaction == null)
            {
                return NotFound();
            }

            var json = JsonConvert.SerializeObject(transaction, Newtonsoft.Json.Formatting.Indented);
            return Content(json, "application/json");
        }


    }
}