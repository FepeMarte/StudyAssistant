using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudyAssistant.Models;

namespace StudyAssistant.Controllers
{
    public class AdministratorsController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Administrator administrator)
        {
            return RedirectToAction("Management");
        }

        [HttpGet]
        public IActionResult Management()
        {
            return View();
        }
    }
}