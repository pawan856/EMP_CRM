using Microsoft.EntityFrameworkCore;
using EMP_CRM.Data;
using EMP_CRM.Models;
using System.Linq;


namespace EMP_CRM.Services
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(List<Employee> Employees, int TotalCount)> GetEmployeesAsync(
               string SearchTerm,
               string SelectedDepartment,
               string SelectedType,
               int PageNumber,
               int PageSize)
        {
            var query = _context.Employees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                query = query.Where(e => EF.Functions.Like(e.FullName, $"%{SearchTerm}%"));
            }

            //if (!string.IsNullOrEmpty(SearchTerm))
            //{
            //    query = query.Where(e => e.FullName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase));
            //}

            if (!string.IsNullOrEmpty(SelectedDepartment))
            {
                if (Enum.TryParse(SelectedDepartment, out Department department))
                {
                    query = query.Where(e => e.Department == department);
                }
            }

            if (!string.IsNullOrEmpty(SelectedType))
            {
                if (Enum.TryParse(SelectedType, out EmployeeType type))
                {
                    query = query.Where(e => e.Type == type);
                }
            }

            int totalCount = await query.CountAsync();

            var employees = await query
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            return (employees, totalCount);
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await GetEmployeeByIdAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
