using SproutSolution.Core.Interface;
using SproutSolution.Core.Model;
using System;

namespace SproutSolution.Core.Factory
{
    public class ConcreteEmployeeFactory : EmployeeFactory
    {
        public override IFactory Factory(Employee employee)
        {
            switch (employee.EmployeeType)
            {
                case EmployeeType.RegularEmployee:
                    return new RegularEmployee(employee);
                case EmployeeType.ContractualEmployee:
                    return new ContractualEmployee(employee);
                default:
                    throw new ApplicationException(string.Format("This type of employee can not be created"));
            }
        }
    }
}
