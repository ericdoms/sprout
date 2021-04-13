using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SproutSolution.Core.Interface
{
    public interface IFactory
    {
        Task<decimal> GetSalary();
    }
}
