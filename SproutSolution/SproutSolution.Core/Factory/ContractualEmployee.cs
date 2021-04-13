using SproutSolution.Core.Interface;
using SproutSolution.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SproutSolution.Core.Factory
{
    public class ContractualEmployee : IFactory
    {
        private Employee _employee;
        private readonly decimal _dailyRate = 500;
        public ContractualEmployee(Employee employee)
        {
            _employee = employee;
        }
        public async Task<decimal> GetSalary()
        {
            return Math.Round((_dailyRate * _employee.Days),2);
        }
    }
}
