using EMP_CRM.Models;
using EMP_CRM.Services;
using EMP_CRM.ViewModels;   
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace EmployeePortal.Controllers
{

    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> List(
            [FromQuery] string SearchTerm,
            [FromQuery] string SelectedDepartment,
            [FromQuery] string SelectedType,
            [FromQuery] int PageNumber = 1,
            [FromQuery] int PageSize = 5)
        {
            (IEnumerable<Employee> employees, int totalCount) = await _employeeService.GetEmployeesAsync(SearchTerm, SelectedDepartment, SelectedType, PageNumber, PageSize);

            var viewModel = new EmployeeListViewModel
            {
                Employees = employees.ToList(),
                PageNumber = PageNumber,
                PageSize = PageSize,
                TotalPages = (int)Math.Ceiling((double)totalCount / PageSize),
                SearchTerm = SearchTerm,
                SelectedDepartment = SelectedDepartment,
                SelectedType = SelectedType
            };

            GetSelectLists();
            ViewBag.PageSizeOptions = new SelectList(new List<int> { 3, 5, 10, 15, 20, 25 }, PageSize);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            GetSelectLists();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.CreateEmployeeAsync(employee);
                return RedirectToAction("Success", new { id = employee.Id });
            }

            GetSelectLists();
            return View(employee);
        }

        public async Task<IActionResult> Success([FromRoute] int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        public async Task<IActionResult> Details([FromRoute] int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            GetSelectLists();
            return View(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.UpdateEmployeeAsync(employee);
                TempData["Message"] = $"Employee with ID {employee.Id} and Name {employee.FullName} has been updated.";
                return RedirectToAction("List");
            }

            GetSelectLists();
            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed([FromRoute] int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            await _employeeService.DeleteEmployeeAsync(id);
            TempData["Message"] = $"Employee with ID {id} and Name {employee.FullName} has been deleted.";

            return RedirectToAction("List");
        }


        
            [HttpGet]
        public JsonResult GetPositions(Department department)
        {
            var positions = new Dictionary<Department, List<string>>
            {
                { Department.IT, new List<string> { "Software Developer", "System Administrator", "Network Engineer" } },
                { Department.HR, new List<string> { "HR Specialist", "HR Manager", "Talent Acquisition Coordinator" } },
                { Department.Sales, new List<string> { "Sales Executive", "Sales Manager", "Account Executive" } },
                { Department.Admin, new List<string> { "Office Manager", "Executive Assistant", "Receptionist" } }
            };

            var result = positions.ContainsKey(department) ? positions[department] : new List<string>();

            return Json(result);
        }

        private void GetSelectLists()
        {
            ViewBag.DepartmentOptions = new SelectList(Enum.GetValues(typeof(Department)).Cast<Department>());
            ViewBag.EmployeeTypeOptions = new SelectList(Enum.GetValues(typeof(EmployeeType)).Cast<EmployeeType>());

        }
        
    }
}
