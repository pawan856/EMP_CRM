using System;
using EMP_CRM;
using EMP_CRM.Models;
using System.Collections.Generic;

namespace EMP_CRM.Models
{
    public class EmployeeListViewModel
    {
        // List of employees to be displayed
        public List<Employee> Employees { get; set; }

        // Total number of pages for pagination
        public int TotalPages { get; set; }

        // Search term for filtering employees
        public string SearchTerm { get; set; }

        // Selected department filter
        public string SelectedDepartment { get; set; }

        // Selected type filter (e.g., full-time, part-time)
        public string SelectedType { get; set; }

        // Number of items per page for pagination
        public int PageSize { get; set; }

        // Current page number for pagination
        public int PageNumber { get; set; }

        // Constructor to initialize properties with default values
        public EmployeeListViewModel()
        {
            Employees = new List<Employee>();
            PageSize = 10; // Default page size
            PageNumber = 1; // Default page number
        }
    }

}