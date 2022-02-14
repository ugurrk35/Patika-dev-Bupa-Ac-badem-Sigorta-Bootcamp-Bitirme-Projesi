using Bupa.Admin.Models;
using Bupa.Admin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Bupa.Admin.Controllers
{
    public class HomeController : Controller
    {


        private readonly ILogger<HomeController> _logger;
        private IApi _api;
        public HomeController(ILogger<HomeController> logger, IApi api)
        {
            _logger = logger;
            _api = api;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index()
        {
            var data = _api.GetList<OrderViewModel>("/api/Order/all").Result;

            //var orders = _apiService.GetList << OrderRootObject > ("api/Orders/GetAll").Result;
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult CustomerList()
        {
            var data = _api.GetList<CustomerList>("/api/Customer").Result;

            //var orders = _apiService.GetList << OrderRootObject > ("api/Orders/GetAll").Result;
            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
