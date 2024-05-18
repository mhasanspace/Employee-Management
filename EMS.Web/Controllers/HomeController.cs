﻿using EMS.Utility.Helper;
using EMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var appUserLogin = SessionHelper.GetAppUserLogin(HttpContext.Session);
            if (appUserLogin == null)
            {
                return RedirectToAction("Login", "AuthenticateUser");
            }

            ViewBag.UserFullName = appUserLogin.UserFullName;
            ViewBag.DesignationName = appUserLogin.DesignationName;
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