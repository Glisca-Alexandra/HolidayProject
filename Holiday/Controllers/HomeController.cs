﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Holiday.Models;
using Microsoft.AspNetCore.Authorization;

namespace Holiday.Controllers
{
  [Authorize(Roles="Admin,Operational,HumanResource")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       
        public IActionResult Index()
        {
            return View();
        }
     
        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize(Roles = "HumanResource")]
        public IActionResult HumanResource()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {
            return View();
        }
        [Authorize(Roles = "Operational")]
        public IActionResult OperationalRole()
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
