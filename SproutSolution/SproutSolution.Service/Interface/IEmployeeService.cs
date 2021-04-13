using SproutSolution.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SproutSolution.Service.Interface
{
    public interface IEmployeeService
    {
        void CreateEmployee(Employee employee);
        decimal GetSalary(Employee employee);
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(Guid employeeId);
    }
}
