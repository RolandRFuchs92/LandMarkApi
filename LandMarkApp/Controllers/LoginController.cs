using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LandMarkAPI.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LandMarkApp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

	    public IActionResult Login(LoginFormViewModel loginDetails)
	    {
		    return View();
	    }
    }
}