using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP1.Models;

namespace TP1.Controllers
{
    public class Tp1Controller : Controller
    {
        private readonly ILogger<Tp1Controller> _logger;

        public Tp1Controller(ILogger<Tp1Controller> logger)
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