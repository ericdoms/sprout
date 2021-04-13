using SproutSolution.Core.Interface;
using SproutSolution.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SproutSolution.Core.Factory
{
    public class RegularEmployee : IFactory
    {
        private Employee _employee;
        private readonly decimal _basicMonthlySalary = 20000;
        private readonly decimal _tax = 12;
        
        public RegularEmployee(Employee employee)
        {
            _employee = employee;
        }
        public decimal GetSalary()
        {
            decimal ratePerDay = (_basicMonthlySalary / 22);
            decimal computedTax = (_basicMonthlySalary * (_tax / 100));
            return Math.Round(((_basicMonthlySalary - (ratePerDay * _employee.Days)) - computedTax),2);
        }
    }
}
