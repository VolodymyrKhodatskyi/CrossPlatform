using Lab5.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers
{
    [Controller]
    public class CustomerAddressesController : Controller
    {
        private readonly Lab6API _lab6APIService;

        public CustomerAddressesController(Lab6API lab6APIService)
        {
            _lab6APIService = lab6APIService;
        }


        [Route("/CustomerAddresses")]
        public async Task<IActionResult> Index()
        {

            var addresses = await _lab6APIService.GetCustomerAddressesAsync();
            return View(addresses);
        }


        [Route("/CustomerAddresses/details/{id}")]
        public async Task<IActionResult> Details(int id)
        {

            var address = await _lab6APIService.GetCustomerAddressesAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }
    }
}
