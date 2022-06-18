using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestMVCApp.Models
{
    public class EmployeeDTO
	{
		public int EmployeeId { get; set; }
		[Required(ErrorMessage = "Please enter ")]
		[DisplayName("UserName")]
		public string EmpName { get; set; }
		[DisplayName("Description")]
		public string EmpDesg { get; set; }
		[DisplayName("Salary")]
		public decimal EmpSal { get; set; }
		[DisplayName("Grade")]
		public string EmpGrade { get; set; }

		[Required(ErrorMessage = "Please enter ")]
		public string Password { get; set; }
		[DisplayName("Confirm Password")]
		public string ConfirmPassword { get; set; }

        public bool IsLogin { get; set; }
    }
}