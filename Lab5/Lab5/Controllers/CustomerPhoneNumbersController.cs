using Lab5.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers
{
    public class CustomerPhoneNumbersController : Controller
    {
        private readonly Lab6API _lab6APIService;

        public CustomerPhoneNumbersController(Lab6API lab6APIService)
        {
            _lab6APIService = lab6APIService;
        }


        [Route("/CustomerPhoneNumbers")]
        public async Task<IActionResult> Index()
        {
            var token = Request.Cookies["AccessToken"] ?? "";

            var customerPhoneNumbers = await _lab6APIService.GetCustomerPhoneNumbersAsync();
            return View(customerPhoneNumbers);
        }


        [Route("/CustomerPhoneNumbers/details/{id}")]
        public async Task<IActionResult> Details(int id)
        {

            var customerPhoneNumbers = await _lab6APIService.GetCustomerPhoneNumbersAsync(id);
            if (customerPhoneNumbers == null)
            {
                return NotFound();
            }
            return View(customerPhoneNumbers);
        }
    }
}