using Lab6.Data;
using Lab6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Xml;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace Lab6.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ApplicationContext _context;

        public SearchController(ApplicationContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Search(DateTime? date, [FromQuery] List<int>? TypeCodes, string? valueStart, string? valueEnd)
        {
            var query = _context.CustomerPhoneNumbers
                .Include(t => t.Customers)
                .Include(t => t.RefCustomerNumberTypes)
                .AsQueryable();

            if (date.HasValue)
            {
                query = query.Where(t => t.HeldFromDate.Date == date.Value.Date);
            }

            if (TypeCodes != null && TypeCodes.Any())
            {
                query = query.Where(t => TypeCodes.Contains(t.CustomerNumberTypeCode));
            }

            if (!string.IsNullOrEmpty(valueStart))
            {
                query = query.Where(t => t.RefCustomerNumberTypes.NumberTypeDescription.StartsWith(valueStart));
            }

            if (!string.IsNullOrEmpty(valueEnd))
            {
                query = query.Where(t => t.RefCustomerNumberTypes.NumberTypeDescription.EndsWith(valueEnd));
            }

            var result = await query
                .Select(t => new
                {
                    CustomerId = t.CustomerId,
                    CustomerNumberTypeCode = t.CustomerNumberTypeCode,
                    HeldFromDate = t.HeldFromDate,
                    HeldToDate = t.HeldToDate,
                    OtherDetails = t.OtherDetails ?? string.Empty
                })
                .ToListAsync();

            var json = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);

            return Content(json, "application/json");
        }
    }
}

