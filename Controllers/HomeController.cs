using Microsoft.AspNetCore.Mvc;
using ModelTrainWebApp.Models;
using System.Diagnostics;

namespace ModelTrainWebApp.Controllers
{
    // Project requirement: Create an additional class which inherits one or more properties from its parent
    public class HomeController : Controller    //HomeController inherits from Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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