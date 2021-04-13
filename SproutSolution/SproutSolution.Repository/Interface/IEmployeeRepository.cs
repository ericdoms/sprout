using SproutSolution.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SproutSolution.Repository.Interface
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(Guid id);
        void CreateEmployee(Employee employee);
        void ClearEmployeeCache();
    }
}
