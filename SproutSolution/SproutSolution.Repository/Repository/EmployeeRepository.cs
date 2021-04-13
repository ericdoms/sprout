using Newtonsoft.Json;
using SproutSolution.Core.Dictionary;
using SproutSolution.Core.Model;
using SproutSolution.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SproutSolution.Repository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private static object _lock = new object();
        private static EmployeeDictionary _cache;

        private EmployeeDictionary GetCacheManager()
        {
            if (_cache == null)
            {
                _cache = new EmployeeDictionary();
            }
            return _cache;
        }

        public void CreateEmployee(Employee employee)
        {
            employee.EmployeeId = Guid.NewGuid();
            var key = string.Format("EmployeeId-{0}", employee.EmployeeId.ToString());
            lock (_lock)
            {
                _cache = GetCacheManager();
                _cache.Add(key, employee);
            };
        }

        public void ClearEmployeeCache()
        {
            _cache = new EmployeeDictionary();
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            if(_cache == null)
            {
                return null;
            }
            return _cache.Select(x => x.Value).ToList();
        }

        public async Task<Employee> GetEmployeeById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
