﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xabaril.Core;

namespace InMemory.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFeaturesService _features;

        public HomeController(IFeaturesService features)
        {
            _features = features;
        }

        public async Task<IActionResult> Index()
        {
            if (await _features.IsEnabledAsync("MyFeature"))
            {
                ViewData["Message"] = "My Feature Is Active";
            }
            else
            {
                ViewData["Message"] = "My Feature Is NOT Active";
            } 

            return View();
        }
    }
}
