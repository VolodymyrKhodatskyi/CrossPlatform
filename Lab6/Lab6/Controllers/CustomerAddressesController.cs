using Lab6.Data;
using Lab6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Xml;
using Microsoft.AspNetCore.Authorization;

namespace Lab6.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerAddressesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CustomerAddressesController(ApplicationContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var addresses = await _context.Addresses
                .Select(a => new
                {

                    Line1 = a.Line1 ?? string.Empty,
                    Line2 = a.Line2 ?? string.Empty,
                    Line3 = a.Line3 ?? string.Empty,
                    City = a.City ?? string.Empty,
                    ZipPostcode = a.ZipPostcode,
                    StateProvinceCountry = a.StateProvinceCountry ?? string.Empty,
                    Country = a.Country ?? string.Empty,
                    OtherDetails = a.OtherDetails ?? string.Empty
                })
                .ToListAsync();

            var json = JsonConvert.SerializeObject(addresses, Newtonsoft.Json.Formatting.Indented);
            return Content(json, "application/json");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddress(int id)
        {
            var address = await _context.Addresses
                .Where(a => a.AddressId == id)
                .Select(a => new
                {

                    Line1 = a.Line1 ?? string.Empty,
                    Line2 = a.Line2 ?? string.Empty,
                    Line3 = a.Line3 ?? string.Empty,
                    City = a.City ?? string.Empty,
                    ZipPostcode = a.ZipPostcode,
                    StateProvinceCountry = a.StateProvinceCountry ?? string.Empty,
                    Country = a.Country ?? string.Empty,
                    OtherDetails = a.OtherDetails ?? string.Empty
                })
                .FirstOrDefaultAsync();

            if (address == null)
            {
                return NotFound();
            }

            var json = JsonConvert.SerializeObject(address, Newtonsoft.Json.Formatting.Indented);
            return Content(json, "application/json");
        }
    }
}
