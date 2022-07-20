using LoginAndLogoutFunctionality.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginAndLogoutFunctionality.Controllers
{
    public class LoginController : Controller
    {
        LoginAndLogoutFunctionalityEntities db = new LoginAndLogoutFunctionalityEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(tbl_user s)
        {
            if(ModelState.IsValid == true)
            {
                var row = db.tbl_user.Where(model => model.username == s.username && model.password == s.password).FirstOrDefault();
                if(row == null)
                {
                    ViewBag.Message = "Invalid User Name or Password";
                    return View();
                }
                else
                {
                    Session["Username"] = s.username;
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }
    }
}