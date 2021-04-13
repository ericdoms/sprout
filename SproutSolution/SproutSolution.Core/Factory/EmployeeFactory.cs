using SproutSolution.Core.Interface;
using SproutSolution.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SproutSolution.Core.Factory
{
    public abstract class EmployeeFactory
    {
        public abstract IFactory Factory(Employee employee);
    }
}
