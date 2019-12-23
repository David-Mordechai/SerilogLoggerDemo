using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            try
            {
                for (var i = 0; i < 100; i++)
                {
                    if (i == 56)
                        throw new Exception("We throw custom exception...");
                    else
                        _logger.LogInformation("the value of i is {LoopValue}", i);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "our loop throws exception when i is 56...");
            }
           
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
