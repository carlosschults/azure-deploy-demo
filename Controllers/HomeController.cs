using AzureDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AzureDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewData["Environment"] = _configuration["ASPNETCORE_ENVIRONMENT"] ?? "Unknown";
            ViewData["Slot"] = Environment.GetEnvironmentVariable("WEBSITE_SLOT_NAME") ?? "local";
            ViewData["Value"] = _configuration["MyConfig:NormalValue"] ?? "Not found";
            ViewData["Secret"] = _configuration["MyConfig:SecretValue"] ?? "Not found";
            ViewData["DotNetVersion"] = Environment.Version.ToString();
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
