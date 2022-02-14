using Bupa.WebUI.Models;
using Bupa.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Bupa.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IApiService _apiService;

        public HomeController(ILogger<HomeController> logger, IApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public IActionResult Index(int? id, string? p)
        {
            
            TempData["id"] = id;
            TempData["p"] = p;
         
            var data = _apiService.GetList<ProductViewModel>("/api/Product").Result;

            //var orders = _apiService.GetList << OrderRootObject > ("api/Orders/GetAll").Result;
      
            return View(data);
        }
        public IActionResult GetProduct()
        {
            return View();
        }
        public IActionResult deneme()
        {
       
            var data = _apiService.GetList<ProductViewModel>("/api/Product").Result;

            //var orders = _apiService.GetList << OrderRootObject > ("api/Orders/GetAll").Result;
            return View(data);
        }
        
        public IActionResult Checkout()
        {
            var fiyat = TempData["p"];

            var id = TempData["id"];
            ViewBag.Date = DateTime.Now;
           
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutModel data)
        {
        
            ViewBag.Date = DateTime.Now.ToString("yyyy'-'MM'-'dd't'HH':'mm':'ss");
            var result = _apiService.Posts("api/Order", data);
            if (result.Id != 0)
            {
                return RedirectToAction("Ordersucces");
            }

    
            return BadRequest("Not a valid model");
            //bir hata oluştu
        }
      
     
        public IActionResult Privacy()
        {
            
            return View();
        }
        public IActionResult Ordersucces()
        {
            return View();
        }
        public IActionResult Hata()
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
