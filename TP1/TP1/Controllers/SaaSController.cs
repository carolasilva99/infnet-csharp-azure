using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP1.Models;

namespace TP1.Controllers
{
    public class SaaSController : Controller
    {
        private readonly ILogger<SaaSController> _logger;

        public SaaSController(ILogger<SaaSController> logger)
        {
            _logger = logger;
        }

        public IActionResult SaaS()
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