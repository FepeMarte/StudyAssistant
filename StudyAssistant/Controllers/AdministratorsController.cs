using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudyAssistant.Models;
using StudyAssistant.Dados;
using Microsoft.EntityFrameworkCore;

namespace StudyAssistant.Controllers
{
    public class AdministratorsController : Controller
    {

        private readonly SAContexto _Context;

        public AdministratorsController(SAContexto context)
        {
            _Context = context;
        }

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
                return RedirectToAction("Management");
            }
            
            return View(administrator);
        }

        [HttpGet]
        public IActionResult Management()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Error = "";
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register([Bind("Name","Email","Password")] Administrator administrator)
        {
            if (!ModelState.IsValid)
            {
                return View(administrator);
            }

            var objAdm = await _Context.Administrators.FirstOrDefaultAsync(adm => adm.Email == administrator.Email);

            if (objAdm == null)
            {
                _Context.Add(administrator);
                _Context.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Error = "Email já cadastrado!";
                return View(administrator);
            }
            
        }




    }
}