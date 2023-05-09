using CRUD_ASp_MVC_CORE.DAL;
using CRUD_ASp_MVC_CORE.Models;
using CRUD_ASp_MVC_CORE.Models.DBEntities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography.X509Certificates;

namespace CRUD_ASp_MVC_CORE.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly EmployeeDbContex _contex;
		public EmployeeController(EmployeeDbContex context)
		{
			this._contex = context;
		}
		[HttpGet]
		public IActionResult Index()
		{
			var employees = _contex.Employees.ToList();
			List<EmployeeViewModel> employeelist = new List<EmployeeViewModel>();
			if (employees != null)
			{
				foreach (var employee in employees)
				{
					var EmployeeViewModel = new EmployeeViewModel()
					{
						ID = employee.ID,
						FirstName = employee.FirstName,
						LastName = employee.LastName,
						DateOfBirth = employee.DateOfBirth,
						Email = employee.Email,
						Salary = employee.Salary,
					};
					employeelist.Add(EmployeeViewModel);
				}
				return View(employeelist);
			}
			return View(employeelist);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Create(EmployeeViewModel EmployeeData)
		{
			try
			{

				if (ModelState.IsValid)
				{
					var Employee = new Employee()
					{
						FirstName = EmployeeData.FirstName,
						LastName = EmployeeData.LastName,
						DateOfBirth = EmployeeData.DateOfBirth,
						Email = EmployeeData.Email,
						Salary = EmployeeData.Salary,
					};
					_contex.Employees.Add(Employee);
					_contex.SaveChanges();
					TempData["Success Message"] = "Employee Created Succefully";
					return RedirectToAction("index");
				}
				else
				{
					TempData["Error Message"] = "Model Data Is Not Valid..";
					return View();
				}

			}
			catch (Exception ex)
			{
				TempData["Error Message"] = ex.Message;
				return View();
				throw;
			}

		}
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var employee = _contex.Employees.SingleOrDefault(x => x.ID == id);
			try
			{

				if (employee != null)
				{
					var employeeView = new EmployeeViewModel()
					{
						ID = employee.ID,
						FirstName = employee.FirstName,
						LastName = employee.LastName,
						DateOfBirth = employee.DateOfBirth,
						Email = employee.Email,
						Salary = employee.Salary,

					};
					return View(employeeView);
				}

				else
				{
					TempData["Error message"] = $"Employee Details is not available with id:{id}";
					return RedirectToAction("Index");
				}
				


			}
			catch (Exception ex)
			{
				TempData["Error Message"] = ex.Message;
				return RedirectToAction("Index");
			}
		}
		[HttpPost]
		public IActionResult Edit(EmployeeViewModel model)
		{
			try
			{

				if (ModelState.IsValid)
				{
					var Employee = new Employee()
					{
						ID = model.ID,
						FirstName = model.FirstName,
						LastName = model.LastName,
						DateOfBirth = model.DateOfBirth,
						Email = model.Email,
						Salary = model.Salary
					};
					_contex.Employees.Update(Employee);
					_contex.SaveChanges();
					TempData["Success Message"] = "Employee Details Updated Successfully";
					return RedirectToAction("index");
				}
				else
				{
					TempData["Error Message"] = "Model data is Envalid";
					return View();
				}
			}
			catch (Exception ex)
			{
				TempData["Error Message"] = ex.Message;
				return View();

			}
		}
		[HttpGet]
		public IActionResult Delete(int id)
		{
			var employee = _contex.Employees.SingleOrDefault(x => x.ID == id);
			try
			{

				if (employee != null)
				{
					var employeeView = new EmployeeViewModel()
					{
						ID = employee.ID,
						FirstName = employee.FirstName,
						LastName = employee.LastName,
						DateOfBirth = employee.DateOfBirth,
						Email = employee.Email,
						Salary = employee.Salary,

					};
					return View(employeeView);
				}

				else
				{
					TempData["Error message"] = $"Employee Details is not available with id:{id}";
					return RedirectToAction("Index");
				}



			}
			catch (Exception ex)
			{
				TempData["Error Message"] = ex.Message;
				return RedirectToAction("Index");
			}
		}
		[HttpPost]
		public IActionResult Delete(EmployeeViewModel model)
		{
			var employee = _contex.Employees.SingleOrDefault(x=>x.ID==model.ID);
			try
			{
				if (employee != null)
				{
					_contex.Employees.Remove(employee);
					_contex.SaveChanges();
					TempData["Error Message"] = "Data Deleted Successfully";
					return RedirectToAction("Index");
				}
				else
				{
					TempData["Error message"] = $"Employee Details is not available with id:{model.ID}";
					return RedirectToAction("Index");
				}


			}
			catch (Exception ex)
			{

				TempData["Error Message"] = ex.Message;
				return RedirectToAction("Index");
			}

			
			
		}
	}
}
		
	
	

	

