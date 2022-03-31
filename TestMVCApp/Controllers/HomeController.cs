using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVCApp.Models;

namespace TestMVCApp.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			if (TempData["EmpTempData"] != null)
			{
				var empData = (EmployeeDTO)TempData["EmpTempData"];
			}
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		public ActionResult Authentication() {
			ViewBag.Message = "Your login page.";
			return View();
		}
	}
}