using System.Diagnostics;
using BookStore.Models;
using BookStore.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var products = _unitOfWork.ProductRepository.GetAll(includedProperties: "Catergory");
            return View(products);
        }

        public IActionResult Detail(int id)
        {
            var product = _unitOfWork.ProductRepository.Get(p => p.Id == id, includedProperties: "Catergory");
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
