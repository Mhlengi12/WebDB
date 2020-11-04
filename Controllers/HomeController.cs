using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebDB.Models;
using MailKit.Net.Smtp;
using MailKit;

namespace WebDB.Controllers
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
            var users = new List<User>
            {
                new User {id=1, name = "Jack"},
                new User { id = 2, name = "King" },
                new User {id=3, name = "Solo"}
        };
            //ViewData["Users"] = users;
            return View(users);
        }

        public class User
        {
            public int id { get; set; }
            public string name { get; set; }
        }

        public IActionResult UserRegister()
        {
            return View();
        }

//must create userregister html
        [HttpPost]
        public IActionResult UserRegister(UserRegister formData)
        {

            if(ModelState.IsValid)
            {
                return (View(formData));
            }
            else
            {
                TempData["Message"] = "Account Registered";
                return RedirectToAction("Index");
            }
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
