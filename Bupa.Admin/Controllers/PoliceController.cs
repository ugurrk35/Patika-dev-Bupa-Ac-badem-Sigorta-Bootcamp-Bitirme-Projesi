using Bupa.Admin.Models;
using Bupa.Admin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Bupa.Admin.Controllers
{
    public class PoliceController : Controller
    {

        private IApi _api;
        public PoliceController( IApi api)
        {
           
            _api = api;
        }
        // GET: PoliceController
        public ActionResult Index()
        {
            var data = _api.GetList<ProductList>("api/Product").Result;

            //var orders = _apiService.GetList << OrderRootObject > ("api/Orders/GetAll").Result;
            return View(data);
        }

        // GET: PoliceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PoliceController/Create
        public async Task<IActionResult> Create(ProductAdd data)
        {
            var result = _api.Posts("api/Product", data);
            if (ModelState.IsValid)
            {
                return View();
                //başarıyla kaydedildi
            }

     ;
            return BadRequest("Not a valid model");
            //bir hata oluştu

        }

   


        // GET: PoliceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PoliceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PoliceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PoliceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
