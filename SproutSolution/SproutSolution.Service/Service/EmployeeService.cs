using SproutSolution.Core.Factory;
using SproutSolution.Core.Interface;
using SproutSolution.Core.Model;
using SproutSolution.Repository.Interface;
using SproutSolution.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SproutSolution.Service.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async void CreateEmployee(Employee employee)
        {
            try
            {
                _employeeRepository.CreateEmployee(employee);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Employee> GetEmployeeById(Guid employeeId)
        {
            try
            {
                return await _employeeRepository.GetEmployeeById(employeeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            try
            {
                return await _employeeRepository.GetEmployees();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<decimal> GetSalary(Employee employee)
        {
            EmployeeFactory EmployeeFactory = new ConcreteEmployeeFactory();
            switch(employee.EmployeeType)
            {
                case EmployeeType.RegularEmployee:
                    IFactory regularEmployee = EmployeeFactory.Factory(employee);
                    return await regularEmployee.GetSalary();
                case EmployeeType.ContractualEmployee:
                    IFactory contractualEmployee = EmployeeFactory.Factory(employee);
                    return await contractualEmployee.GetSalary();
                default:
                    return 0;
            }
        }
    }
}
