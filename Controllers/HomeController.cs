using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTapi_application.Models;
using Services;

namespace RESTapi_application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClient _apiClient;

        public HomeController(ILogger<HomeController> logger, IClient apiclient)
        {
            _logger = logger;
            _apiClient = apiclient;
        }

        public async Task<IActionResult> Index()
        {
            var user = new Services.User
            {
                UserName = "Vladimir",
                Password = "hovno123",
                Email = "vlad@gmail.com"
            };

            await _apiClient.CreateUserAsync(user);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Girls()
        {
            var data = await _apiClient.GetGirlsAsync(true);
            var girls = data.ToList();
            return View(girls);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
