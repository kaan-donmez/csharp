using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Caching.InMemory
{
    public class ProductController : Controller
    {

        private IMemoryCache memoryCache;
        public ProductController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            memoryCache.Set("time", DateTime.Now.ToString());
            return View();
        }

        public IActionResult Show()
        {
            ViewBag.time = memoryCache.Get("time");
            return View();
        }
    }
}

