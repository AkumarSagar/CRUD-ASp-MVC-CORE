using CRUD_ASp_MVC_CORE.Models.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_ASp_MVC_CORE.DAL
{
	public class EmployeeDbContex : DbContext
	{


		public EmployeeDbContex(DbContextOptions options) : base(options)
		{

		}
		public DbSet<Employee> Employees { get; set; }
	}
}
