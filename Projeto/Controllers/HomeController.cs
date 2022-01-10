﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Quemsomos()
        {
            return View();
        }

        public IActionResult SindromeDeDown()
        {
            return View();
        }

        public IActionResult OqueFazemos()
        {
            return View();
        }

        public IActionResult PqContratar()
        {
            return View();
        }

        public IActionResult Capacitacao()
        {
            return View();
        }


        public IActionResult CRUD()
        {
            return View();
        }

        public IActionResult Index()
        {
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
