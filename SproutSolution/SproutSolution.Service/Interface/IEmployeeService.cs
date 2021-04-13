using SproutSolution.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SproutSolution.Service.Interface
{
    public interface IEmployeeService
    {
        void CreateEmployee(Employee employee);
        Task<decimal> GetSalary(Employee employee);
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(Guid employeeId);
    }
}
