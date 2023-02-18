using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP1.Models;

namespace TP1.Controllers
{
    public class PaaSController : Controller
    {
        private readonly ILogger<PaaSController> _logger;

        public PaaSController(ILogger<PaaSController> logger)
        {
            _logger = logger;
        }

        public IActionResult PaaS()
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