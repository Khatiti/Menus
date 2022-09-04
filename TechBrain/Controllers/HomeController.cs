using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TechBrain.Models;

namespace TechBrain.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            MenuViewModel mvm = new MenuViewModel();
            ViewBag.MainMenus = mvm.MainMenu;
            return View();
        }

    }
}
