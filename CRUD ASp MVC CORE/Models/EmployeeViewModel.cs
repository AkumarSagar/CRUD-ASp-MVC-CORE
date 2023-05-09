using System.ComponentModel;

namespace CRUD_ASp_MVC_CORE.Models
{
	public class EmployeeViewModel
	{
		public int ID { get; set; }
		[DisplayName("First Name")]
		public string FirstName { get; set; }
		[DisplayName("Last Name")]
		public string LastName { get; set; }
		[DisplayName("Date Of Birth")]
		public DateTime DateOfBirth { get; set; }
		[DisplayName("E-Mail")]
		public string Email { get; set; }
		public double Salary { get; set; }

		[DisplayName("Name")]
		public string FullName
		{
			get { return FirstName + "" + LastName; }
		}
	}
}
