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
using PresentationLayer;
using PresentationLayer.Models;

namespace LayerPageLearn.Controllers
{
    public class HomeController : Controller
    {
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;
        public HomeController(DataManager content)
        {
            _datamanager = content;
            _servicesmanager = new ServicesManager(_datamanager);
        }
        public IActionResult Index()
        {
            List<DirectoryViewModel> _dirs = _servicesmanager.Directorys.GetDirectoryesList();
            return View(_dirs);
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
