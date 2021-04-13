using SproutSolution.Core.Factory;
using SproutSolution.Core.Interface;
using SproutSolution.Core.Model;
using SproutSolution.Repository.Interface;
using SproutSolution.Service.Interface;
using System;
using System.Collections.Generic;

namespace SproutSolution.Service.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void CreateEmployee(Employee employee)
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

        public Employee GetEmployeeById(Guid employeeId)
        {
            try
            {
                return _employeeRepository.GetEmployeeById(employeeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                return _employeeRepository.GetEmployees();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal GetSalary(Employee employee)
        {
            EmployeeFactory EmployeeFactory = new ConcreteEmployeeFactory();
            switch(employee.EmployeeType)
            {
                case EmployeeType.RegularEmployee:
                    IFactory regularEmployee = EmployeeFactory.Factory(employee);
                    return regularEmployee.GetSalary();
                case EmployeeType.ContractualEmployee:
                    IFactory contractualEmployee = EmployeeFactory.Factory(employee);
                    return contractualEmployee.GetSalary();
                default:
                    return 0;
            }
        }
    }
}
