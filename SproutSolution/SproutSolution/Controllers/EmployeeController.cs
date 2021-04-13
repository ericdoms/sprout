using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SproutSolution.Core.Model;
using SproutSolution.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SproutSolution.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeeService.GetEmployees();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee GetEmployeeById(Guid id)
        {
            return _employeeService.GetEmployeeById(id);
        }

        // GET api/<EmployeeController>/GetSalary
        [HttpPost("GetSalary")]
        public Decimal GetSalary([FromBody] Employee employee)
        {
            return _employeeService.GetSalary(employee);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] Employee employee)
        {
            _employeeService.CreateEmployee(employee);
        }
    }
}
