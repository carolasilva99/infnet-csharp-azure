using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TP1.Models;

namespace TP1.Controllers
{
    public class IaaSController : Controller
    {
        private readonly ILogger<IaaSController> _logger;

        public IaaSController(ILogger<IaaSController> logger)
        {
            _logger = logger;
        }

        public IActionResult IaaS()
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