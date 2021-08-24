using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VerstaTestTask.Filters;
using VerstaTestTask.Infrastructure;
using VerstaTestTask.Models;

namespace VerstaTestTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly OrdersViewModelService _ordersService;

        public HomeController(OrdersViewModelService ordersService)
        {
            this._ordersService = ordersService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateOrderViewModel]
        public async Task<IActionResult> Index(OrderViewModel order)
        {
            var id = await _ordersService.AddAsync(order);
            TempData["CreatedOrderId"] = id;

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Orders(int page = 1)
        {
            var totalOrders = await _ordersService.CountAsync();
            var pagination = new PaginationViewModel(totalOrders)
            {
                CurrentPage = page
            };
            ViewBag.Pagination = pagination;

            var orderViewModels = await _ordersService.GetOrdersForPage(pagination);

            return View(orderViewModels);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}