using Lab5.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers
{
    [Controller]
    public class CustomersController : Controller
    {
        private readonly Lab6API _lab6APIService;

        public CustomersController(Lab6API lab6APIService)
        {
            _lab6APIService = lab6APIService;
        }


        [Route("/Customers")]
        public async Task<IActionResult> Index()
        {
            var token = Request.Cookies["AccessToken"] ?? "";

            var customers = await _lab6APIService.GetCustomersAsync(token);
            return View(customers);
        }


        [Route("/Customers/details/{id}")]
        public async Task<IActionResult> Details(int id)
        {

            var customer = await _lab6APIService.GetCustomerAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
    }
}