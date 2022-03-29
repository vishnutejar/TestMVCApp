using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMVCApp.Models
{
	public class EmployeeDTO
	{
		public int EmployeeId { get; set; }
		public string EmpName { get; set; }
		public string EmpDesg { get; set; }
		public decimal EmpSal { get; set; }
		public string EmpGrade { get; set; }
	}
}