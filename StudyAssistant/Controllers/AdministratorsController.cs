using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudyAssistant.Models;
using StudyAssistant.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

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
            ViewBag.Error = "";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email,Password")] Administrator administrator)
        {
            if (!ModelState.IsValid)
            {
                var objAdm = await _Context.Administrators.FirstOrDefaultAsync(adm => adm.Email == administrator.Email && adm.Password == administrator.Password);

                if (objAdm == null)
                {
                    ViewBag.Error = "Email e/ou Senha inválidos!";
                    return View();
                }
                else
                {
                    HttpContext.Session.SetString("Name", objAdm.Name);
                    HttpContext.Session.SetInt32("Id", objAdm.Id);

                    return RedirectToAction("Management");
                }

            }
            
            return View(administrator);
        }

        [HttpGet]
        public IActionResult Management()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            ViewBag.Id = HttpContext.Session.GetInt32("Id");

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

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }


    }
}