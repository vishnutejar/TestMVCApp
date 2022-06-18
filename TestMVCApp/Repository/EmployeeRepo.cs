using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestMVCApp.Models;

namespace TestMVCApp.Repository
{
	public class EmployeeRepo
	{
		public List<EmployeeDTO> GetEmployeeById(int id)
		{
			var employeeList = GetEmployees().Where(m=>m.EmployeeId==id).ToList();
			return employeeList;
		}
			
		public List<EmployeeDTO> GetEmployees()
		{
			List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();
			for (int i = 0; i <= 5; i++)
			{
				employeeDTOs.Add(new EmployeeDTO
				{
					EmployeeId = i,
					EmpDesg = "EmpDesg " + i.ToString(),
					EmpGrade = "E" + i.ToString(),
					EmpName = "Name " + i.ToString(),
					EmpSal = 12500 + i,
				});
			}
			return employeeDTOs;
		}
		
	}
}