using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TestMVCApp.Models;
using TestMVCApp.Repository;

namespace TestMVCApp.Controllers
{
    //[Auth]
    public class EmployeeController : Controller
    {
        public List<EmployeeDTO> GetEmployeeSessionData()
        {
            List<EmployeeDTO> emp = new List<EmployeeDTO>();
            if (Session["EmpData"] != null)
            {
                emp = (List<EmployeeDTO>)Session["EmpData"];
            }
            else
            {
                emp = employeeRepo.GetEmployees();
                Session["EmpData"] = emp;
            }
            return emp;
        }
        EmployeeRepo employeeRepo = new EmployeeRepo();
        // GET: Employee
        public ActionResult Index(string EmpName, string Password = null)
        {
            var emp = GetEmployeeSessionData();

            if (ValidateAuthentation(EmpName))
            {
                return View(emp);
            }
            else {
                return View("~/Views/LoginAndSignUp/Login.cshtml");
            }
        }
        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            var emp = GetEmployeeSessionData();
            var empDetails = emp.Where(m => m.EmployeeId == id).SingleOrDefault();
            return View(empDetails);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        //public ActionResult Create(FormCollection collection)
        public ActionResult Create(EmployeeDTO employeeDTO)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var emp = GetEmployeeSessionData();
                    emp.Add(new EmployeeDTO
                    {
                        EmployeeId = employeeDTO.EmployeeId,
                        EmpDesg = employeeDTO.EmpDesg,
                        EmpGrade = employeeDTO.EmpGrade,
                        EmpName = employeeDTO.EmpName,
                        EmpSal = employeeDTO.EmpSal,
                        Password = employeeDTO.Password,
                        IsLogin = true
                    });
                    Session["EmpData"] = emp;
                    //ViewData["confimMsg"] = "Employee added successfully";
                }
                //TempData["EmpTempData"] = employeeDTO;
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        public ActionResult Edit(EmployeeDTO employeeDTO)
        {
            try
            {
                var empInfo = GetEmployeeSessionData();
                foreach (var item in empInfo)
                {
                    if (item.EmployeeId == employeeDTO.EmployeeId)
                    {
                        item.EmployeeId = employeeDTO.EmployeeId;
                        item.EmpDesg = employeeDTO.EmpDesg;
                        item.EmpSal = employeeDTO.EmpSal;
                        item.EmpGrade = employeeDTO.EmpGrade;
                        item.EmpName = employeeDTO.EmpName;
                    }
                }
                Session["EmpData"] = empInfo;
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            //var empInfo = employeeRepo.GetEmployees().Where(m => m.EmployeeId != id).ToList();
            var empInfo = GetEmployeeSessionData();
            empInfo = empInfo.Where(m => m.EmployeeId != id).ToList();
            Session["EmpData"] = empInfo;
            return RedirectToAction("Index");
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Authentication(string EmpName, string Password = null)
        {
            if (ValidateAuthentation(EmpName))
            {
                return View("~/Views/Home/Index.cshtml");
            }
            else
            {
                return View("~/Views/Shared/Error.cshtml");
            }
        }
        [HttpPost]
        public ActionResult ForgotPasswordValidation(string Password,string ConfirmPassword) {

            return View();
        }

        public bool ValidateAuthentation(string EmpName)
        {

            var empInfo = GetEmployeeSessionData();
            var LoginResult = empInfo.Where(m => m.EmpName.Equals(EmpName)).ToList();
            if (LoginResult != null)
            {
                if (LoginResult.Count > 0)
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
