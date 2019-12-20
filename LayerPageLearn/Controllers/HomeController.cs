using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LayerPageLearn.Models;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using BuissnessLayer;

namespace LayerPageLearn.Controllers
{
    public class HomeController : Controller
    {
        private DataManager _datamanager;
        public HomeController(DataManager content)
        {
            _datamanager = content;
        }
        public IActionResult Index()
        {
            var model = _datamanager.Directorys.GetAllDirectorys(true).ToList();
            return View(model);
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
