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
        public IActionResult Login([Bind("Email,Password")] Administrator administrator)
        {
            if (!ModelState.IsValid)
            {
                return View(administrator);
            }
            return RedirectToAction(nameof(Management));
            
        }

        [HttpGet]
        public IActionResult Management()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(Administrator administrator)
        {
            return RedirectToAction("Login");
        }

    }
}