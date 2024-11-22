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
    public class CustomersController : Controller
    {
        private readonly ApplicationContext _context;

        public CustomersController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var transactions = await _context.Customers
                .Select(t => new
                {
                    CustomerName = t.CustomerName ?? string.Empty,
                    CustomerEmail = t.CustomerEmail ?? string.Empty,
                    CustomerAddress = t.CustomerAddress ?? string.Empty,
                    CommercialOrDomestic = t.CommercialOrDomestic ?? string.Empty,
                    OtherCustomerDetails = t.OtherCustomerDetails ?? string.Empty

                })
                .ToListAsync();

            var json = JsonConvert.SerializeObject(transactions, Newtonsoft.Json.Formatting.Indented);
            return Content(json, "application/json");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomers(int id)
        {
            var transaction = await _context.Customers
                .Where(t => t.CustomerId == id)
                .Select(t => new
                {
                    CustomerName = t.CustomerName ?? string.Empty,
                    CustomerEmail = t.CustomerEmail ?? string.Empty,
                    CustomerAddress = t.CustomerAddress ?? string.Empty,
                    CommercialOrDomestic = t.CommercialOrDomestic ?? string.Empty,
                    OtherCustomerDetails = t.OtherCustomerDetails ?? string.Empty
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
