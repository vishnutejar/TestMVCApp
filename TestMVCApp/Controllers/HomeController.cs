using System.Web.Mvc;
using TestMVCApp.Models;

namespace TestMVCApp.Controllers
{
    public class HomeController : Controller
	{
		public ActionResult Index(string EmpName, string Password = null)
		{
				if (TempData["EmpTempData"] != null)
			{
				var empData = (EmployeeDTO)TempData["EmpTempData"];
			}
			return ValidateLogin(EmpName, Password);
		}

		public ActionResult About(string EmpName, string Password = null)
		{

			return ValidateLogin(EmpName,Password);

		}
		public ActionResult Register()
		{

			return View("~/Views/Employee/Create.cshtml");

		}
		public ActionResult ForgotPassword()
		{
			return View("~/Views/Home/ForgotPassword.cshtml");
		}
		private ViewResult ValidateLogin(string username,string password) {
			if (!string.IsNullOrEmpty(username) &&!string.IsNullOrEmpty(password))
			{
				if (username.Equals("vishnu"))
				{
					ViewBag.Message = "Your application description page.";
					return View();
				}
				else
				{
					return View("~/Views/LoginAndSignUp/Login.cshtml");

				}
			}
			else
			{
				return View("~/Views/LoginAndSignUp/Login.cshtml");

			}
		}
		public ActionResult Contact(string EmpName, string Password = null)
		{
			//ViewBag.Message = "Your contact page.";

			return ValidateLogin(EmpName, Password);
		}
		public ActionResult Login() 
		{
			//ViewBag.Message = "Your contact page.";

			return ValidateLogin("", "");
		}
		
		public ActionResult ForgotPasswordValidation(string Password, string ConfirmPassword)
		{

			return View();
		}
	}
}