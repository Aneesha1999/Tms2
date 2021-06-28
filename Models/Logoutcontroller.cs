using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tms2.Models
{
    public class Logoutcontroller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.msg = HttpContext.Session.GetString("username");
            if(ViewBag.msg != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Create", "logins");
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Create", "logins");
        }
    }
}
