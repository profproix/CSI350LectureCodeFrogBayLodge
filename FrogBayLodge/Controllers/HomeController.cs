using FrogBayLodge.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FrogBayLodge.Controllers
{
    public class HomeController : Controller
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

        //Note Quary Strings 
        public IActionResult Test(string? search)
        {
            return new ContentResult { Content = search };
        // https://localhost:7150/home/test?search=cat
        }
    }
}
