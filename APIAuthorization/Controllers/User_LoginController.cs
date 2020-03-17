using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIAuthorization.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace APIAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User_LoginController : ControllerBase
    {
        private User_LoginContext _userLoginContext;
        
        public User_LoginController(User_LoginContext userLoginContext)
        {
            _userLoginContext = userLoginContext;   
        }

        //[Route("")]
        //[Route("index")]
        //[Route("~/")]
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //[Route("login")]
        //[HttpPost]
        //public IActionResult Login(string username, string password)
        //{
        //    if (username != null && password != null && username.Equals("acc1") && password.Equals("123"))
        //    {
        //        HttpContext.Session.SetString("username", username);
        //        return View("Success");
        //    }
        //    else
        //    {
        //        ViewBag.error = "Invalid Account";
        //        return View("Index");
        //    }
        //}

        //[Route("logout")]
        //[HttpGet]
        //public IActionResult Logout()
        //{
        //    HttpContext.Session.Remove("username");
        //    return RedirectToAction("Index");
        //}
    }
}