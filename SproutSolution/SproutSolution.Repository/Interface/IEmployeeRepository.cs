using SproutSolution.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SproutSolution.Repository.Interface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(Guid id);
        void CreateEmployee(Employee employee);
        void ClearEmployeeCache();
    }
}
